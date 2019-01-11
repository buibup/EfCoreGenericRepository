using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreGenericRepository.DAL.Models.Interfaces
{
    public interface IAuditable
    {
        string CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string UpdatedBy { get; set; }
        DateTime? UpdatedOn { get; set; }
    }
}
