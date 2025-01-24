using CylinderProject.Models;

namespace CylinderTestCode
{
    public class UnitTest1
    {
        [Fact]
        public void IsRadiusAndHeightCorrect()
        {
            var newCylinder = new Cylinder(5.22, 7.22);

            Assert.Equal(5.22, newCylinder.Radius);
            Assert.Equal(7.22, newCylinder.Height);
            
        }

        [Theory]
        [InlineData(5.22, 7.22)]
        [InlineData(-5, 7)]
        [InlineData(2, 6)]
        public void IsNullOrNegative(double radius, double height) 
        {
            var cylinder = new Cylinder(radius, height);

            Assert.Throws<ArgumentException>(() => cylinder);
        }

        [Fact]
        public void VolumeAndSurfaceArea()
        {
            var cylinder = new Cylinder(4, 6);

            Assert.Equal(Math.PI * Math.Pow(cylinder.Radius, 2) * cylinder.Height, cylinder.GetVolume(), precision: 4);
            Assert.Equal(2 * Math.PI * Math.Pow(cylinder.Radius, 2) + 2 * Math.PI * cylinder.Radius * cylinder.Height, cylinder.GetSurfaceArea(), precision: 4);
        }


        [Theory]
        [InlineData(2,5.2)]
        [InlineData(2.9,2)]
        [InlineData(8,8.1)]

        public void resizeUpdate(double newRad, double newHe)
        {
            var cylinder = new Cylinder(8, 5.4);
            Assert.Throws<ArgumentException>(() => cylinder.Resize(newRad, newHe));
            cylinder.Resize(newRad, newHe);
            Assert.Equal(newRad, cylinder.Radius);
            Assert.Equal(newHe, cylinder.Height);

        }
        [Fact]
        public void IsNotNull()
        {
            var cylinder = new Cylinder(5, 10);

            Assert.NotNull(cylinder);
        }

        [Fact]
        public void IsRadiusInRange()
        {
            var cyl = new Cylinder(5, 10);

            Assert.InRange(cyl.Radius, 1, 100);
        }
    }
}