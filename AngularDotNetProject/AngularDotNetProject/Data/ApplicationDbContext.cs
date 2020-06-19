using System;
using System.Collections.Generic;
using System.Text;
using AngularDotNetProject.API.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
    
namespace AngularDotNetProject.API.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<Event> Events { get; set; }

/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\SQLEXPRESS;Database=aspnet-AngularDotNetProject-1D3983E6-CCBE-43B9-B0F5-F980B2618C44;Trusted_Connection=True;MultipleActiveResultSets=true");
        }*/
    }
}
