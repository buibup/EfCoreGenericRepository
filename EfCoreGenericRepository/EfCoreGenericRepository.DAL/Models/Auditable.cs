using EfCoreGenericRepository.DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreGenericRepository.DAL.Models
{
    public class Auditable : IAuditable
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
