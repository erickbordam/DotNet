using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KYC360.Core.Models;

namespace KYC360.Core.Data
{
    public class DataSeeder
    {
        private readonly GenericMockDatabase<Entity, string> _database;

        public DataSeeder(GenericMockDatabase<Entity, string> database)
        {
            _database = database;
        }

        public void Seed()
        {
            var entity1 = new Entity
            {
                Id = "entity1",
                Addresses = new List<Address>
                {
                    new Address { Id = 1, AddressLine = 1, City = 2, Country = 3 }
                },
                Dates = new List<Date>
                {
                    new Date { Id = 1, DateType = "Birth", DateVal = new DateTime(1980, 4, 15) }
                },
                Deceased = false,
                Gender = "Male",
                Names = new List<Name>
                {
                    new Name { Id = 1, FirstName = "John", MiddleName = "H.", Surname = "Doe" }
                }
            };

            var entity2 = new Entity
            {
                Id = "entity2",
                Addresses = new List<Address>
                {
                    new Address { Id = 2, AddressLine = 3, City = 4, Country = 5 }
                },
                Dates = new List<Date>
                {
                    new Date { Id = 2, DateType = "Anniversary", DateVal = new DateTime(2005, 9, 10) }
                },
                Deceased = true,
                Gender = "Female",
                Names = new List<Name>
                {
                    new Name { Id = 2, FirstName = "Jane", MiddleName = "A.", Surname = "Smith" }
                }
            };

            _database.AddItem(entity1);
            _database.AddItem(entity2);
        }
    }
}