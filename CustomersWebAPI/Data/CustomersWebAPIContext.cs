using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomersWebAPI.Models;

namespace CustomersWebAPI.Data
{
    public class CustomersWebAPIContext : DbContext
    {
        public CustomersWebAPIContext (DbContextOptions<CustomersWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<CustomersWebAPI.Models.Customer> Customer { get; set; } = default!;
    }
}
