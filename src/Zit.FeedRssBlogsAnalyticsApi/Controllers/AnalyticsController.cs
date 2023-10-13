using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Zit.FeedRssAnalytics.Domain.Entities;
using Zit.FeedRssAnalytics.Domain.Repositories.AbstractRepository;
using Zit.FeedRssAnalytics.Infra.Data.ORM;
using Zit.FeedRssBlogsAnalyticsApi.DTOs;

namespace Zit.FeedRssBlogsAnalyticsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnalyticsController : Controller
    {
        readonly CultureInfo culture = new("en-US");
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private static readonly object _lockObj = new();

        private readonly IQueryRepository _queryRepository;
        private readonly IMapper _mapper;

        public AnalyticsController(ApplicationDbContext dbContext, IConfiguration configuration, IQueryRepository queryRepository, IMapper mapper)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _queryRepository = queryRepository;
            _mapper = mapper;
        }
       
        [HttpGet]
        [Route("GetCategory/{authorId}")]
        [ProducesResponseType(typeof(List<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Produces("application/json")]
        public async Task<ActionResult<List<CategoryDto>>> GetCategory(string? authorId)
        {
            if (string.IsNullOrWhiteSpace(authorId)) return BadRequest(string.Empty);

            var categories = _mapper.Map<List<CategoryDto>>(await _queryRepository.GetCategoriesByAuthorId(authorId));

            return Ok(categories);
           
        }

        [HttpGet]
        [Route("GetAuthor")]
        public IQueryable<Authors> GetAuthors()
        {
            return _queryRepository.GetAuthors();
        }        
    }
}
