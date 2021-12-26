using Microsoft.EntityFrameworkCore;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Tests
{
    public static class InMemoryDatasource
    {
        public static PClubDbContext GetContext()
        {
            var options = new DbContextOptionsBuilder<PClubDbContext>()
                .UseInMemoryDatabase(databaseName: "PClubInMemoryBase")
                .Options;

            var context = new PClubDbContext(options);
            context.Database.EnsureDeleted();
            FillWithData(context);

            return context;
        }

        private static void FillWithData(PClubDbContext context)
        {
            context.ClubUsers.AddRange(GetClubUsers());
            context.Computers.AddRange(GetComputers());
            context.Entries.AddRange(GetEntries());
        }

        public static Entry[] GetEntries()
        {
            var users = GetClubUsers();
            var computers = GetComputers();

            return new Entry[]
            {
                new Entry
                {
                    Id = 1,
                    VisitStartDateTime = DateTime.Now,
                    VisitEndDateTime = DateTime.Now,
                    ClubUserId = users[0].Id,
                    ComputerId = computers[0].Id,
                },
                new Entry
                {
                    Id = 2,
                    VisitStartDateTime = DateTime.Now,
                    VisitEndDateTime = DateTime.Now,
                    ClubUserId = users[1].Id,
                    ComputerId = computers[2].Id,
                },
                new Entry
                {
                    Id = 3,
                    VisitStartDateTime = DateTime.Now,
                    VisitEndDateTime = DateTime.Now,
                    ClubUserId = users[3].Id,
                    ComputerId = computers[3].Id,
                },
            };
        }

        public static Computer[] GetComputers()
        {
            return new Computer[]
            {
                new Computer
                {
                    Id = 1,
                    Name = "ПК1"
                },
                new Computer
                {
                    Id = 2,
                    Name = "ПК2"
                },
                new Computer
                {
                    Id = 3,
                    Name = "ПК3"
                },
                new Computer
                {
                    Id = 4,
                    Name = "ПК4"
                },
                new Computer
                {
                    Id = 5,
                    Name = "ПК5"
                },
            };
        }

        public static ClubUser[] GetClubUsers()
        {
            return new ClubUser[]
            {
                new ClubUser
                {
                    Id = Guid.Parse("f0480dd4-db92-4d1d-a8fe-92c5f932534b"),
                    FirstName = "Anon",
                    SecondName = "Anton",
                    Email = "amail@gmail.com",
                    PhoneNumber = "8939393939"
                },
                new ClubUser
                {
                    Id = Guid.Parse("b2ffbf8b-572d-4452-bed5-57334c43c403"),
                    FirstName = "Artem",
                    SecondName = "Anon",
                    Email = "amail@gmail.com",
                    PhoneNumber = "8939393939"
                },
                new ClubUser
                {
                    Id = Guid.Parse("34dcefc3-3285-42b8-9825-b758fe6d44b0"),
                    FirstName = "Rustam",
                    SecondName = "Gabdu",
                    Email = "gabdu@gmail.com",
                    PhoneNumber = "8939393939"
                },
                new ClubUser
                {
                    Id = Guid.Parse("1fe97fa1-376a-4072-b4e8-ff1b63cf2c4a"),
                    FirstName = "Roman",
                    SecondName = "Petrovich",
                    Email = "sdf@gmail.com",
                    PhoneNumber = "8939393939"
                }
            };
        }
    }
}
