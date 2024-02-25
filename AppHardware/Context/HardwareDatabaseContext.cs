using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppHardware.Models;

namespace AppHardware.Context
{
    public class HardwareDatabaseContext : DbContext
    {
        public HardwareDatabaseContext(DbContextOptions<HardwareDatabaseContext> options)
      : base(options)
        {
        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Registro> Registros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AppHardware.Models.Stock> Stock { get; set; }

    }
}
