using EfCoreGenericRepository.DAL.Data;
using EfCoreGenericRepository.DAL.DataAccess.Interfaces;
using EfCoreGenericRepository.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreGenericRepository.DAL.DataAccess
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
