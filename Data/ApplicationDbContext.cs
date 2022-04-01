using APIsurveys.Modelos;
using APIsurveys.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsurveys.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Encuesta> Encuestas { get; set; }
        public DbSet<CamposEncuesta> CamposEncuesta { get; set; }

     

    }
}
