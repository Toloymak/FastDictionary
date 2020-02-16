using System;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class FdContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // todo: change to relation path
            options.UseSqlite("Data Source=blogging.db");
        }
        
        public DbSet<OriginalWord> OriginalWords { get; set; }
        public DbSet<TranslateWord> TranslateWord { get; set; }
    }
}