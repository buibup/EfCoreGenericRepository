using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreGenericRepository.DAL.Models
{
    public class Blog : Auditable
    {
        [Key]
        public int BlogId { get; set; }
        public string Title { get; set; }
        public ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
