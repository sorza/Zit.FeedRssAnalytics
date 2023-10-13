using AutoMapper;
using Zit.FeedRssAnalytics.Domain.Entities;
using Zit.FeedRssBlogsAnalyticsApi.DTOs;

namespace Zit.FeedRssBlogsAnalyticsApi.Configurations.Automappers
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Authors, AuthorDto>().ReverseMap();
            CreateMap<Feed, FeedDto>().ReverseMap();
            CreateMap<ArticleMatrix, ArticleMatrixDto>().ReverseMap();
        }
    }
}
