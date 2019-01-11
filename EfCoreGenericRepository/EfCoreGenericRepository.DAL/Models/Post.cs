using System;
using System.ComponentModel.DataAnnotations;

namespace EfCoreGenericRepository.DAL.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime TimeStamp { get; set; }
        public Blog Blog { get; set; }

    }
}