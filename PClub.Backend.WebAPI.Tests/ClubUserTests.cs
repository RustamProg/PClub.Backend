using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
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
    public class ClubUserTests
    {
        private PClubDbContext Context { get; set; }
        private ClubUserController ClubUserController { get; set; }

        [OneTimeSetUp]
        public void Initialize()
        {
            InitDependencies();
        }

        public void InitDependencies()
        {
            Context = InMemoryDatasource.GetContext();
            ClubUserController = new ClubUserController(Context);
        }

        [Test]
        public async Task GetUsersCount_Correct()
        {
            var expectedUsers = await Context.ClubUsers.ToListAsync();
            var actualUsers = await ClubUserController.GetClubUsersAsync();

            expectedUsers.Should().HaveSameCount(actualUsers);
        }

        [Test]
        public async Task GetUsers_Correct()
        {
            var expectedUsers = await Context.ClubUsers.ToListAsync();
            var actualUsers = await ClubUserController.GetClubUsersAsync();

            expectedUsers.Should().BeEquivalentTo(actualUsers);
        }
    }
}
