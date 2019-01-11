using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCoreGenericRepository.DAL.Models
{
    public class BlogDetail
    {
        [Key]
        public int BlogId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Url { get; set; }
    }
}
