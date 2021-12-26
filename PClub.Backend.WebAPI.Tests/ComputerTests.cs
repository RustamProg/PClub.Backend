using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using PClub.Backend.Models;
using PClub.Backend.WebAPI.Controllers;
using PClub.Backend.WebAPI.DataAccess;
using PClub.Backend.WebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PClub.Backend.WebAPI.Tests
{
    [TestFixture]
    public class ComputerTests
    {
        private PClubDbContext Context { get; set; }
        private ComputerController ComputerController { get; set; }
        private Mock<IUserService> UserService { get; set; }

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
            Context = InMemoryDatasource.GetContext();
            ComputerController = new ComputerController(UserService.Object, Context);
        }

        [Test]
        public async Task GetComputersCount_Correct()
        {
            var expectedComputers = await Context.Computers.ToListAsync();
            var actualComputers = await ComputerController.GetComputers();

            expectedComputers.Should().HaveSameCount(actualComputers);
        }

        [Test]
        public async Task GetComputers_Correct()
        {
            var expectedComputers = await Context.Computers.ToListAsync();
            var actualComputers = await ComputerController.GetComputers();

            expectedComputers.Should().BeEquivalentTo(actualComputers);
        }
    }
}
