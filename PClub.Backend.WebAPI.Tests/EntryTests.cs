using AutoMapper;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using PClub.Backend.WebAPI.Controllers;
using PClub.Backend.WebAPI.DataAccess;
using PClub.Backend.WebAPI.Helpers;
using PClub.Backend.WebAPI.Models;
using PClub.Backend.WebAPI.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Tests
{
    [TestFixture]
    public class EntryTests
    {
        private PClubDbContext Context { get; set; }
        private EntryController EntryController { get; set; }
        private Mock<IUserService> UserService { get; set; }
        private IMapper Mapper { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitMocks();
            InitDependencies();
        }

        public void InitMocks()
        {
            UserService = new Mock<IUserService>();
            UserService.Setup(p => p.GetUser()).Returns(InMemoryDatasource.GetClubUsers().First());
        }

        public void InitDependencies()
        {
            var mapperConfig = new MapperConfiguration(cfg => 
                cfg.AddProfile<EntryProfile>()
            );
            Mapper = new Mapper(mapperConfig);
            Context = InMemoryDatasource.GetContext();
            EntryController = new EntryController(Context, UserService.Object, Mapper);
        }

        [Test]
        public async Task GetUserEntries_ReturnsValidData()
        {
            var expectedCount = 0;

            var actualEntries = await EntryController.GetUserEntries();

            actualEntries.Should().HaveCount(expectedCount);
        }
    }
}
