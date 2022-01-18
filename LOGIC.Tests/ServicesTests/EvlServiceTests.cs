using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using LOGIC.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LOGIC.Tests.ServicesTests
{
    public class EvlServiceTests
    {

        [Fact]
        public async Task CreateEvlTests()
        {
            // Arrange
            var evl = new Evl();
            var EvlRepository = new Mock<IEvlRepository>();
            EvlRepository.Setup(x => x.Create(evl)).ReturnsAsync(evl);
            var sut = new EvlService(EvlRepository.Object);

            // Act
            var result = await sut.CreateEvl(evl);

            // Assert
            Assert.True(result.Success);
        }
    }

}
