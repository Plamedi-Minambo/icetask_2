using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using icetask2.Models;

namespace icetask2.Data
{
    public class icetask2Context : DbContext
    {
        public icetask2Context (DbContextOptions<icetask2Context> options)
            : base(options)
        {
        }

        public DbSet<icetask2.Models.Order> Order { get; set; } = default!;
    }
}
