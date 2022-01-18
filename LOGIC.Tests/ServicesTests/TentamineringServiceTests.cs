using LOGIC.Interfaces.Files;
using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using LOGIC.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LOGIC.Tests.ServicesTests
{
    public class TentamineringServiceTests
    {
        [Fact]
        public async Task CreateTentamineringTests()
        {
            // Arrange
            var Tentaminering = new Tentaminering();
            var TentamineringRepository = new Mock<ITentamineringRepository>();
            TentamineringRepository.Setup(x => x.Create(Tentaminering)).ReturnsAsync(Tentaminering);
            var RubricsFileBuilder = new Mock<IRubricsFileBuilder>();
            var sut = new TentamineringService(TentamineringRepository.Object, RubricsFileBuilder.Object);

            // Act
            var result = await sut.CreateTentaminering(Tentaminering);

            // Assert
            Assert.True(result.Success);
        }
    }
}
