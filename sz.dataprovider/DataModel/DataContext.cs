using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sz.dataprovider.DataModel
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<sz.commons.models.Article> ArticleTable { get; set; }
        public DbSet<sz.commons.models.Store> StoreTable { get; set; }
    }
}
