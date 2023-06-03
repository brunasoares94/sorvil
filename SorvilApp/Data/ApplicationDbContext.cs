using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SorvilApp.Models;

namespace SorvilApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Perfil> Perfils { get; set; }

        public ApplicationDbContext(DbSet<Perfil> perfils)
        {
            Perfils = perfils;
        }
    }
}