using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciador_Demandas3.Models
{
    public class DemandasContexto : DbContext
    {
        public DbSet<Demandas> Demandas { get; set; }

        public DemandasContexto(DbContextOptions<DemandasContexto> opcoes) : base(opcoes)
        {

        }
    }
}
