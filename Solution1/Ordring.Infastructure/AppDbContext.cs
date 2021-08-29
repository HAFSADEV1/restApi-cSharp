using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordring.WebApi.Models;

namespace Ordring.WebApi
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
       
        //public DbSet<User> users { get; set; }
        public DbSet<Todo> todos { get; set; }

    }
}
