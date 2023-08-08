using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IQSec_PT.Models;

namespace IQSec_PT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<IQSec_PT.Models.Vehiculo>? Vehiculo { get; set; }
        public DbSet<IQSec_PT.Models.Estacionamiento>? Estacionamiento { get; set; }
    }
}