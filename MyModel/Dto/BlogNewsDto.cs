using System;
using MyModel.Model;

namespace MyModel.Dto
{
    public class BlogNewsDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public int LikeCount { get; set; }

 

        public int WriterId { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string TypeName{get;set;}
        public string WriteName { get; set; }
        public string UserName { get; set; }

    }
}
