﻿using API.Modelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        public DbSet<Encuesta> Encuestas { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
