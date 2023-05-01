using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_P1_Raura_Cordero.Models;

namespace Proyecto_P1_Raura_Cordero.Data
{
    public class Proyecto_P1_Raura_CorderoContext : DbContext
    {
        public Proyecto_P1_Raura_CorderoContext (DbContextOptions<Proyecto_P1_Raura_CorderoContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto_P1_Raura_Cordero.Models.Pelicula> Pelicula { get; set; } = default!;
    }
}
