using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Zit.FeedRssAnalytics.Domain.Repositories.AbstractRepository;
using Zit.FeedRssBlogsAnalyticsApi.DTOs;

namespace Zit.FeedRssBlogsAnalyticsApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnalyticsADOController : Controller    {  
      
        private static readonly object _lockObj = new();

        private readonly IQueryADORepository _queryADORepository;
        private readonly IMapper _mapper;

        public AnalyticsADOController(IQueryADORepository queryADORepository, IMapper mapper)
        {

            _queryADORepository = queryADORepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Resumo analítico de Categoria
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns>Retorna uma lista de Categoria por Id</returns>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     GET /Todo
        ///     {
        ///         "name":"Nome da Categoria",
        ///         "count": Qtde de Post na Categoria"
        ///     }
        /// </remarks>
        [HttpGet]
        [Route("GetCategory/{authorId}")]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<CategoryDto>>> GetCategory(string? authorId)
        {
            if (string.IsNullOrWhiteSpace(authorId)) return BadRequest(string.Empty);

            var author = await _queryADORepository.GetCategoriesByAuthorId(authorId);
            if (author == null) return NotFound();

            var categories = _mapper.Map<List<CategoryDto>>(author);

            return Ok(categories);
           
        }

        /// <summary>
        /// Agrupamento de Post por Autor
        /// </summary>
        /// <returns>Retorna um resumo por agrupamento de Post por Autor</returns>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     GET /Todo
        ///     {
        ///         "authorId":"Id do Autor",
        ///         "author":"Nome do Autor",
        ///         "count": Qtde de Post deste Autor"
        ///     }
        /// </remarks>
        [HttpGet]
        [Route("GetAuthor")]
        [ProducesResponseType(typeof(IEnumerable<AuthorDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task <ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
        {
            var iEnumAuthor = await _queryADORepository.GetAuthors();
            return Ok(_mapper.Map<IEnumerable<AuthorDto>>(iEnumAuthor));
        }

        /// <summary>
        /// Retorna uma lista de Feeds (Artigo, Blog, Video etc) do Autor.
        /// </summary>
        /// <returns>Retorna uma lista de Feeds (Artigo, Blog, Video etc) do Autor.</returns>
        /// <remarks>
        /// Retorna uma lista de Feeds (Artigo, Blog, Video etc) do Autor.
        /// Exemplo de Request:
        /// 
        ///     GET /Todo
        ///     {
        ///         "id": "Id do Autor",
        ///         "authorId": "Apelido do autor",
        ///         "author": Nome do autor,
        ///         "link": "Link do Artigo,
        ///         "title": "Titulo do Artigo",
        ///         "type": "Tipo do Artigo,
        ///         "category": "Categoria do Artigo",
        ///         "views": "1.5k",
        ///         "viewsCount": 1500, [exemplo]
        ///         "likes": 2, [exemplo]
        ///         "pubDate": "2023-02-18T00:00:00" [exemplo]
        ///     }
        /// </remarks>
        [HttpGet]
        [Route("GetAll/{authorId}")]
        [ProducesResponseType(typeof(IEnumerable<ArticleMatrixDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ArticleMatrixDto>>> GetAll(string authorId)
        {
            var model = await _queryADORepository.GetAllArticlesByAuthorId(authorId);
            var aMapper = _mapper.Map<IEnumerable<ArticleMatrixDto>>(model);
            return Ok(aMapper);
        }
    }
}
