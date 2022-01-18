using LOGIC.Interfaces.Repositories;
using LOGIC.Models;
using LOGIC.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace LOGIC.Tests.ServicesTests
{
    public class RubricServiceTests
    {
        [Fact]
        public async Task CreateRubricTests()
        {
            // Arrange
            var rubric = new Rubric();
            var RubricRepository = new Mock<IRubricRepository>();
            RubricRepository.Setup(x => x.Create(rubric)).ReturnsAsync(rubric);
            var sut = new RubricService(RubricRepository.Object);

            // Act
            var result = await sut.CreateRubric(rubric);

            // Assert
            Assert.True(result.Success);
        }
    }
}
