using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Principal_G4.Repositories;
using TP_Principal_G4.Repositories.Contracts;

namespace TP_Principal_G4.Test
{
    public class AnimalControllerBaseUnitTest
    {
        protected IAnimalRepository _animalRepository;
        protected TpPrincipalG4Context _context;

        public AnimalControllerBaseUnitTest()
        {
            var dbContextOptions = new DbContextOptionsBuilder<TpPrincipalG4Context>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _context = new TpPrincipalG4Context(dbContextOptions);
            DbContextUtils.SeedData(_context);

            _animalRepository = new AnimalRepository(_context);
        }
    }
}
