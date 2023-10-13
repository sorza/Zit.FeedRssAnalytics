using Zit.FeedRssAnalytics.Domain.Entities;

namespace Zit.FeedRssAnalytics.Domain.Repositories.AbstractRepository
{
    public interface IQueryRepository
    {
        Task<IEnumerable<Category>> GetCategoriesByAuthorId(string authorId);
        IQueryable<Authors> GetAuthors();
    }
}
