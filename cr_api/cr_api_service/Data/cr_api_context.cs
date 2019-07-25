using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cr_api_service.Models;
using Microsoft.EntityFrameworkCore;

namespace cr_api_service.Data
{
    public class cr_api_context : DbContext {
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public cr_api_context(DbContextOptions<cr_api_context> options) : base(options) { }
    }
}
