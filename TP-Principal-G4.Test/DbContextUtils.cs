using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Principal_G4.Entities;
using TP_Principal_G4.Test.SeedData;

namespace TP_Principal_G4.Test
{
    internal class DbContextUtils
    {
        public static void SeedData(TpPrincipalG4Context context)
        {
            //using var context = new TpPrincipalG4Context(dbContextOptions);

            // Crea razas si no hay
            if (!context.Razas.Any())
            {
                context.Razas.AddRange(EntitiesSeed.GenerateRazas());
                context.SaveChanges();
            }

            // Crea refugios si no hay
            if (!context.Refugios.Any())
            {
                context.Refugios.AddRange(EntitiesSeed.GenerateRefugios());
                context.SaveChanges();
            }

            // Crea animales si no hay
            if (!context.Animales.Any())
            {
                context.Animales.AddRange(EntitiesSeed.GenerateAnimales());
                context.SaveChanges();
            }
        }
    }
}
