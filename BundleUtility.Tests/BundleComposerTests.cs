using Xunit;

namespace BundleUtility.Tests
{
    public class BundleComposerTests
    {
        [Fact]
        public void TestCalculateMaxBundles_Bike()
        {
            // Arrange
            Part root = new Part("Bike", 1, int.MaxValue); // Max value is to represent a bandle that needs to be calculated
            Part seat = new Part("Seat", 1, 50);
            Part pedals = new Part("Pedals", 2, 60);
            Part wheels = new Part("Wheels", 2, int.MaxValue);
            Part frame = new Part("Frame", 1, 60);
            Part tube = new Part("Tube", 1, 35);

            root.SubParts.Add(seat);
            root.SubParts.Add(pedals);
            root.SubParts.Add(wheels);

            wheels.SubParts.Add(frame);
            wheels.SubParts.Add(tube);

            // Act
            BundleComposer calculator = new BundleComposer();
            int maxBundles = calculator.CalculateMaxBundles(root);

            // Assert
            Assert.Equal(17, maxBundles);
        }

        [Fact]
        public void TestCalculateMaxBundles_EmptyTree()
        {
            // Arrane
            BundleComposer calculator = new BundleComposer();

            // Act
            int maxBundles = calculator.CalculateMaxBundles(null);

            // Assert
            Assert.Equal(0, maxBundles);
        }

        [Fact]
        public void TestCalculateMaxBundles_SinglePart_Invalid()
        {
            // Arrange
            Part root = new Part("Root", 5, int.MaxValue);

            BundleComposer calculator = new BundleComposer();

            // Act
            int maxBundles = calculator.CalculateMaxBundles(root);

            // Assert
            Assert.Equal(int.MinValue, maxBundles);
        }
    }
}
