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
            var table = new Table(1, "��������� ����", "���� ��� ������ ����", 4, "������");

            zoo.AddThing(table);

            Assert.Single((List<Thing>)typeof(Zoo).GetField("_things", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(zoo));
        }

        [Fact]
        public void AddThingComputer_AddsThingToZoo()
        {
            var mockClinic = new Mock<IVeterinaryClinic>();
            var zoo = new Zoo(mockClinic.Object);
            var computer = new Computer(1, "�������", "����������� ���������", "Dell", 16);

            zoo.AddThing(computer);

            Assert.Single((List<Thing>)typeof(Zoo).GetField("_things", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(zoo));
        }

        [Fact]
        public void Computer_DisplayInfo_PrintsCorrectInformation()
        {
            var computer = new Computer(1, "�������", "����������� ���������", "Dell", 16);

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                computer.DisplayInfo();

                var output = stringWriter.ToString(); 
                Assert.Contains("ID: 1", output);
                Assert.Contains("��������: �������", output);
                Assert.Contains("�����: Dell", output);
                Assert.Contains("���: 16 ��", output);
            }

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }

        [Fact]
        public void Table_DisplayInfo_PrintsCorrectInformation()
        {
            var table = new Table(1, "��������� ����", "���� ��� ������ ����", 4, "������");

            using (var stringWriter = new StringWriter())
            {
                Console.SetOut(stringWriter);
                table.DisplayInfo();

                var output = stringWriter.ToString();
                Assert.Contains("ID: 1", output);
                Assert.Contains("��������: ��������� ����", output);
                Assert.Contains("���������� �����: 4", output);
                Assert.Contains("��������: ������", output);
            }

            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}