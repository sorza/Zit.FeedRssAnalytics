using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zit.FeedRssAnalytics.Domain.Entities;
using Zit.FeedRssAnalytics.Domain.Repositories.AbstractRepository;
using Zit.FeedRssAnalytics.Infra.Data.ORM;

namespace Zit.FeedRssAnalytics.Infra.Repositories.ImplementationsRepository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QueryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public IQueryable<Authors> GetAuthors()
        {
            return _dbContext.ArticleMatrices.GroupBy(a => a.AuthorId)
                   .Select(g =>
                        new Authors
                        {
                            AuthorId = g.FirstOrDefault().AuthorId,
                            Author = g.FirstOrDefault().Author,
                            Count = g.Count()
                        })
                   .OrderBy(g => g.Author);
        }
     

        public async Task<IEnumerable<Category>> GetCategoriesByAuthorId(string authorId)
        {
            var retval = await _dbContext.ArticleMatrices
                  .Where(x => x.AuthorId == authorId)
                  .GroupBy(x => x.Category)
                  .Select(group => new Category
                  {
                      Name = group.FirstOrDefault().Category,
                      Count = group.Count()
                  }).ToListAsync();

            return retval;
        }
    }
}
