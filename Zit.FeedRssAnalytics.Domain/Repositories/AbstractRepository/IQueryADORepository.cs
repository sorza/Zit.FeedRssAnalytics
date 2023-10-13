using Zit.FeedRssAnalytics.Domain.Entities;

namespace Zit.FeedRssAnalytics.Domain.Repositories.AbstractRepository
{
    public interface IQueryADORepository
    {
        Task<IEnumerable<Category>> GetCategoriesByAuthorId(string authorId);
        Task<IEnumerable<Authors>> GetAuthors();
        Task<IEnumerable<ArticleMatrix>> GetAllArticlesByAuthorId(string authorId);
    }
}
