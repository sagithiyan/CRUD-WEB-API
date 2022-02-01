using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Store.API.Data
{
    public class BookStroreContext : DbContext 
    {
        public BookStroreContext(DbContextOptions<BookStroreContext> options) :base(options)
        
        { 
        
        
        }

        public DbSet<Books> Books { get; set; }


       

    }
}
