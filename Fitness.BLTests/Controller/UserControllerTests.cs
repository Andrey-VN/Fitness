using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {

            //Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller = new UserController(userName);

            //Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller1 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller1.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller1.CurrentUser.BrithDate);
            Assert.AreEqual(weight, controller1.CurrentUser.Wright);
            Assert.AreEqual(height, controller1.CurrentUser.Height);
            Assert.AreEqual(gender, controller1.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();


            //Act
            var controller = new UserController(userName);


            //Assert
            Assert.AreEqual(userName, controller.CurrentUser.Name);
           
        }
    }
}