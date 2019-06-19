using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortalStudent.Common.Domain;
using PortalStudent.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCasesTests
{
    [TestClass()]
    public class AdminRole_AddSandwishInMenuTests
    {
        [TestMethod()]
        public void AdminRole_ReturnTrue_WhenValidSandwishIsProvided()
        {
            //Arrange
            var SandwishToUse = new Sandwich { Name = "Thon Piquant2" };

            //Act
            var adminRole = new AdminRole();

            var resultAdd = adminRole.AddSandwishInMenu(SandwishToUse);

            //Assert
            Assert.IsTrue(resultAdd);
        }

        [TestMethod()]
        public void AdminRole_ThrowException_WhenExistentSandwishIsProvided()
        {
            //Arrange
            var SandwishToUse = new Sandwich { Name = "Sand1" };

            //Act
            var adminRole = new AdminRole();

            //Assert
            Assert.ThrowsException<Exception>(() => adminRole.AddSandwishInMenu(SandwishToUse));
        }

        [TestMethod()]
        public void AdminRole_ThrowException_WhenInvalidSandwishIsProvided()
        {
            //Arrange
            var SandwishToUse = new Sandwich();

            //Act
            var adminRole = new AdminRole();

            //Assert
            Assert.ThrowsException<Exception>(() => adminRole.AddSandwishInMenu(SandwishToUse));
        }

        [TestMethod()]
        public void AdminRole_ThrowException_WhenNullSandwishIsProvided()
        {
            //Arrange
            var SandwishToUse = new Sandwich();

            //Act
            var adminRole = new AdminRole();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => adminRole.AddSandwishInMenu(null));
        }
    }
}