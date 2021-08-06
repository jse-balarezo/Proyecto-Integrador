using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoIntegrador.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoIntegrador.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Operadora> Operadoras { get; set; }
        public DbSet<Plan> Planes { get; set; }
    }
}
