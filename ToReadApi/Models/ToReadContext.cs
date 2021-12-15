using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ToReadApi.Models
{
    public class ToReadContext : DbContext
    {
        public ToReadContext(DbContextOptions<ToReadContext> options) : base(options)
        {
        }

        public DbSet<ToReadItem> ToReadItems { get; set; }
    }

}
