using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using LOGIC.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LOGIC.Tests.ServicesTests
{
    public class LeeruitkomstServiceTests
    {
        [Fact]
        public async Task CreateLeeruitkomstTests()
        {
            // Arrange
            var leeruitkomst = new Leeruitkomst();
            var LeeruitkomstRepository = new Mock<ILeeruitkomstRepository>();
            LeeruitkomstRepository.Setup(x => x.Create(leeruitkomst)).ReturnsAsync(leeruitkomst);
            var sut = new LeeruitkomstService(LeeruitkomstRepository.Object);

            // Act
            var result = await sut.CreateLeeruitkomst(leeruitkomst);

            // Assert
            Assert.True(result.Success);
        }
    }
}
