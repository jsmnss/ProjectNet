using NUnit.Framework;
using WebAPI.Logic;
using WebAPI.Models;

namespace WebAPI.Test
{
    [TestFixture]
    public class TestEmployee
    {
        /// <summary>
        /// Prueba para validar el metodo que genera el salario anual
        /// </summary>
        [Test]
        public void TestAnnualSalary()
        {
            double salary = 5000;
            double annualSalary = 60000;

            Assert.AreEqual(annualSalary, EmployeeOperation.GenerateAnnualSalary(salary));

        }
        /// <summary>
        /// Prueba para validar el metodo que genera el salario anual
        /// </summary>
        [Test]
        public void TestAnnualSalaryTwo()
        {
            double salary = 100;
            double annualSalary = 1200;

            Assert.AreEqual(annualSalary, EmployeeOperation.GenerateAnnualSalary(salary));

        }
    }
}
