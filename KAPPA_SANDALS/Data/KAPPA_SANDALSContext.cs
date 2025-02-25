using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KAPPA_SANDALS.Models;

namespace KAPPA_SANDALS.Data
{
    public class KAPPA_SANDALSContext : DbContext
    {
        public KAPPA_SANDALSContext (DbContextOptions<KAPPA_SANDALSContext> options)
            : base(options)
        {
        }

        public DbSet<KAPPA_SANDALS.Models.Sandal> Sandal { get; set; } = default!;
    }
}
