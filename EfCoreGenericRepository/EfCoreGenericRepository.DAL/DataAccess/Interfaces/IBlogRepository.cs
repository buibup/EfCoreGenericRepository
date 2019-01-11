using EfCoreGenericRepository.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreGenericRepository.DAL.DataAccess.Interfaces
{
    public interface IBlogRepository : IGenericRepository<Blog>
    {
    }
}
