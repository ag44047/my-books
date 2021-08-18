using System;
using Microsoft.EntityFrameworkCore;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(oprions)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
 