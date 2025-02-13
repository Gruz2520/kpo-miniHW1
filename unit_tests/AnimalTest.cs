using lib_miniHW1;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace unit_tests
{
    public class AnimalTest
    {
        [Fact]
        public void AddMonkey_AddsHealthyAnimalToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var animal = new Monkey(1, 5, 8);

            zoo.AddAnimal(animal);

            Assert.Single(zoo.GetAnimalsForPettingZoo());
        }

        [Fact]
        public void AddRabbit_AddsHealthyAnimalToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var animal = new Rabbit(1, 5, 8);

            zoo.AddAnimal(animal);

            Assert.Single(zoo.GetAnimalsForPettingZoo());
        }


        [Fact]
        public void AddWolf_AddsHealthyAnimalToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var wolf = new Wolf(1, 5);

            zoo.AddAnimal(wolf);

            var animalsField = typeof(Zoo).GetField("_animals", BindingFlags.NonPublic | BindingFlags.Instance);
            var animals = (List<Animal>)animalsField.GetValue(zoo);

            Assert.Single(animals);
            Assert.Equal("Wolf", animals.First().GetType().Name); 
        }

        [Fact]
        public void AddTiger_AddsHealthyTigerToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var tiger = new Tiger(1, 10);

            zoo.AddAnimal(tiger);

            var animalsField = typeof(Zoo).GetField("_animals", BindingFlags.NonPublic | BindingFlags.Instance);
            var animals = (List<Animal>)animalsField.GetValue(zoo);

            Assert.Single(animals);
            Assert.Equal("Tiger", animals.First().GetType().Name);
        }

        [Fact]
        public void AddAnimal_AddsMultipleAnimalsToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var monkey = new Monkey(1, 5, 8);
            var tiger = new Tiger(2, 10);
            var wolf = new Wolf(3, 12) ;

            zoo.AddAnimal(monkey);
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(wolf);

            Assert.Equal(1, zoo.GetAnimalsForPettingZoo().Count());
            Assert.Contains(zoo.GetAnimalsForPettingZoo(), a => a.GetType().Name == "Monkey");
            Assert.DoesNotContain(zoo.GetAnimalsForPettingZoo(), a => a.GetType().Name == "Tiger");
            Assert.DoesNotContain(zoo.GetAnimalsForPettingZoo(), a => a.GetType().Name == "Wolf");
        }

        [Fact]
        public void AddRabbit_AddsUnHealthyAnimalToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(false);

            var zoo = new Zoo(mockClinic.Object);
            var animal = new Rabbit(1, 0, 8);

            zoo.AddAnimal(animal);

            Assert.Empty(zoo.GetAnimalsForPettingZoo());
        }


        [Fact]
        public void AddWolf_AddsUnHealthyAnimalToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var animal = new Wolf(1, 5);

            zoo.AddAnimal(animal);

            Assert.Empty(zoo.GetAnimalsForPettingZoo());
        }

        [Fact]
        public void AddTiger_AddsUnHealthyTigerToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var tiger = new Tiger(1, 10);

            zoo.AddAnimal(tiger);

            Assert.Empty(zoo.GetAnimalsForPettingZoo());
        }
        [Fact]
        public void AddAnimal_DoesNotAddUnhealthyAnimal()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(false);

            var zoo = new Zoo(mockClinic.Object);
            var animal = new Monkey(1, 0, 8);

            zoo.AddAnimal(animal);

            Assert.Empty(zoo.GetAnimalsForPettingZoo());
        }


        [Fact]
        public void GetAnimalsForPettingZoo_ReturnsFriendlyAnimals()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var friendlyMonkey = new Monkey(1, 5, 8);
            var unfriendlyMonkey = new Monkey(2, 5, 3);

            zoo.AddAnimal(friendlyMonkey);
            zoo.AddAnimal(unfriendlyMonkey);

            var friendlyAnimals = zoo.GetAnimalsForPettingZoo();

            Assert.Single(friendlyAnimals);
            Assert.Equal("Monkey", friendlyAnimals.First().GetType().Name);
        }

        [Fact]
        public void GetAnimalsForPettingZoo_ExcludesUnfriendlyAnimals()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var unfriendlyMonkey = new Monkey(1, 5, 5);

            zoo.AddAnimal(unfriendlyMonkey);

            var friendlyAnimals = zoo.GetAnimalsForPettingZoo();

            Assert.Empty(friendlyAnimals);
        }

        [Fact]
        public void GetAnimalsForPettingZoo_ExcludesUnfriendlyAnimalsTigerWolf()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var unfriendlyWolf = new Wolf(1, 5);

            zoo.AddAnimal(unfriendlyWolf);

            var unfriendlyTiger = new Tiger(1, 5);

            zoo.AddAnimal(unfriendlyTiger);

            var friendlyAnimals = zoo.GetAnimalsForPettingZoo();

            Assert.Empty(friendlyAnimals);
        }

        [Fact]
        public void GetAnimalsForPettingZoo_excludMonkeyTigerWolf()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var unfriendlyWolf = new Wolf(1, 5);

            zoo.AddAnimal(unfriendlyWolf);

            var unfriendlyTiger = new Tiger(1, 5);

            zoo.AddAnimal(unfriendlyTiger);

            var unfriendlyMonkey = new Monkey(1, 5, 0);

            zoo.AddAnimal(unfriendlyMonkey);

            var friendlyAnimals = zoo.GetAnimalsForPettingZoo();

            Assert.Empty(friendlyAnimals);
        }

        [Fact]
        public void GetAnimalsForPettingZoo_excludTigerWolf()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var unfriendlyWolf = new Wolf(1, 5);

            zoo.AddAnimal(unfriendlyWolf);

            var unfriendlyTiger = new Tiger(1, 5);

            zoo.AddAnimal(unfriendlyTiger);

            var friendlyMonkey = new Monkey(1, 5, 10);

            zoo.AddAnimal(friendlyMonkey);

            var friendlyAnimals = zoo.GetAnimalsForPettingZoo();

            Assert.Single(friendlyAnimals);
            Assert.Equal("Monkey", friendlyAnimals.First().GetType().Name);
        }
    }
}
