using EfCoreGenericRepository.DAL.Data;
using EfCoreGenericRepository.DAL.DataAccess.Interfaces;
using EfCoreGenericRepository.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreGenericRepository.DAL.DataAccess
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
