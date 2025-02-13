using lib_miniHW1;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unit_tests
{
    public class InventTest
    {
        [Fact]
        public void PrintInventory_PrintsEmptyListWhenNoAnimals()
        {
            // Arrange
            var mockClinic = new Mock<IVeterinaryClinic>();
            var zoo = new Zoo(mockClinic.Object);

            // Act & Assert
            using (var consoleOutput = new ConsoleOutput())
            {
                zoo.PrintInventory();
                Assert.Contains("", consoleOutput.GetOutput());
            }
        }

        [Fact]
        public void PrintInventory_PrintsListOfAnimals()
        {
            // Arrange
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var monkey = new Monkey(1, 5, 8);
            zoo.AddAnimal(monkey);

            // Act & Assert
            using (var consoleOutput = new ConsoleOutput())
            {
                zoo.PrintInventory();
                Assert.Contains("Инвентарный номер: 1, Вид: Monkey", consoleOutput.GetOutput());
            }
        }

        [Fact]
        public void PrintInventory_PrintsListOfAnimalsWithUnhealthy()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var monkey = new Monkey(1, 5, 8);
            zoo.AddAnimal(monkey);

            var monkey2 = new Monkey(2, 0, 8);
            zoo.AddAnimal(monkey2);

            using (var consoleOutput = new ConsoleOutput())
            {
                zoo.PrintInventory();
                Assert.Contains("Инвентарный номер: 1, Вид: Monkey", consoleOutput.GetOutput());
            }
        }

        [Fact]
        public void PrintInventory_PrintsListOfMultipleAnimals()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            mockClinic.Setup(c => c.IsHealthy(It.IsAny<Animal>())).Returns(true);

            var zoo = new Zoo(mockClinic.Object);
            var monkey = new Monkey(1, 5, 8) ;
            var tiger = new Tiger(2, 10) ;
            var wolf = new Wolf(3, 12);

            zoo.AddAnimal(monkey);
            zoo.AddAnimal(tiger);
            zoo.AddAnimal(wolf);

            using (var consoleOutput = new ConsoleOutput())
            {
                zoo.PrintInventory();
                Assert.Contains("Инвентарный номер: 1, Вид: Monkey", consoleOutput.GetOutput());
                Assert.Contains("Инвентарный номер: 2, Вид: Tiger", consoleOutput.GetOutput());
                Assert.Contains("Инвентарный номер: 3, Вид: Wolf", consoleOutput.GetOutput());
            }
        }
    }

    public class ConsoleOutput : IDisposable
    {
        private readonly StringWriter _stringWriter;
        private readonly TextWriter _originalOutput;

        public ConsoleOutput()
        {
            _stringWriter = new StringWriter();
            _originalOutput = Console.Out;
            Console.SetOut(_stringWriter);
        }

        public string GetOutput() => _stringWriter.ToString();

        public void Dispose()
        {
            Console.SetOut(_originalOutput);
            _stringWriter.Dispose();
        }
    }
}
