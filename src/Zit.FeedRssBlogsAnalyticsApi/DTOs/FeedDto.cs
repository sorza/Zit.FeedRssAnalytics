﻿namespace Zit.FeedRssBlogsAnalyticsApi.DTOs
{
    public class FeedDto
    {
        public string? Link { get; set; }
        public string? Title { get; set; }
        public string? FeedType { get; set; }
        public string? Content { get; set; }
        public DateTime PubDate { get; set; } = DateTime.Now;

        public FeedDto() 
        {
            Link = string.Empty;
            Title = string.Empty;
            FeedType = string.Empty;
            Content = string.Empty;
            PubDate = DateTime.Today;
        }
    }
}
