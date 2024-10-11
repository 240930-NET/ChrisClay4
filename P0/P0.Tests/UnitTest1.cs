using Xunit;

namespace P0.Tests
{
    public class UnitTest1
    {
        //dotnet test to run tests
        [Fact]
        public void TestAddWin()
        {
            // Arrange
            Helm2 helm = new Helm2();
            Greave greave = new Greave();
            Chest chest = new Chest();
            Hero hero = new Hero("Test Hero", helm, greave, chest);

            // Act
            hero.AddWin();

            // Assert
            Assert.Equal(1, hero.Wins);
        }

        [Fact]
        public void TestAddLoss()
        {
            // Arrange
            Helm2 helm = new Helm2();
            Greave greave = new Greave();
            Chest chest = new Chest();
            Hero hero = new Hero("Test Hero", helm, greave, chest);

            // Act
            hero.AddLoss();

            // Assert
            Assert.Equal(1, hero.Losses);
        }

        [Fact]
        public void TestInitialWinsAndLosses()
        {
            // Arrange
            Helm2 helm = new Helm2();
            Greave greave = new Greave();
            Chest chest = new Chest();
            Hero hero = new Hero("Test Hero", helm, greave, chest);

            // Act/Assert
            Assert.Equal(0, hero.Wins);
            Assert.Equal(0, hero.Losses);
        }
    }
}