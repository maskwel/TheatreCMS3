// ViewModels/BlogAuthorViewModel.cs
using System;
using System.Collections.Generic;
using TheatreCMS3.Areas.Blog.Models;

namespace TheatreCMS3.Areas.Blog.ViewModels
{
    public class BlogAuthorViewModel
    {
        public BlogAuthor BlogAuthor { get; set; }
        public string BlogPhoto { get; set; }
        public List<BlogPostViewModel> BlogPosts { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
    }

    public class BlogPostViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string BlogPhoto { get; set; }
    }
}
