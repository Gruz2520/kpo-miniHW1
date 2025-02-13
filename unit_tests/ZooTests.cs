using Xunit;
using System.Collections.Generic;
using lib_miniHW1;
using kpo_miniHW1;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Collections;

namespace unit_tests
{
    public class ZooTests
    {

        [Fact]
        public void AddThingTable_AddsThingToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            var zoo = new Zoo(mockClinic.Object);
            var table = new Table(1, "Обеденный стол", "Стол для приема пищи", 4, "Дерево");

            zoo.AddThing(table);

            Assert.Single((List<Thing>)typeof(Zoo).GetField("_things", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(zoo));
        }

        [Fact]
        public void AddThingComputer_AddsThingToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            var zoo = new Zoo(mockClinic.Object);
            var computer = new Computer(1, "Ноутбук", "Портативный компьютер", "Dell", 16);

            zoo.AddThing(computer);

            Assert.Single((List<Thing>)typeof(Zoo).GetField("_things", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(zoo));
        }

        [Fact]
        public void Computer_DisplayInfo_PrintsCorrectInformation()
        {
            var computer = new Computer(1, "Ноутбук", "Портативный компьютер", "Dell", 16);

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                computer.DisplayInfo();

                var output = stringWriter.ToString(); 
                Assert.Contains("ID: 1", output);
                Assert.Contains("Название: Ноутбук", output);
                Assert.Contains("Бренд: Dell", output);
                Assert.Contains("ОЗУ: 16 ГБ", output);
            }

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        [Fact]
        public void Table_DisplayInfo_PrintsCorrectInformation()
        {
            var table = new Table(1, "Обеденный стол", "Стол для приема пищи", 4, "Дерево");

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                table.DisplayInfo();

                var output = stringWriter.ToString();
                Assert.Contains("ID: 1", output);
                Assert.Contains("Название: Обеденный стол", output);
                Assert.Contains("Количество ножек: 4", output);
                Assert.Contains("Материал: Дерево", output);
            }

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}