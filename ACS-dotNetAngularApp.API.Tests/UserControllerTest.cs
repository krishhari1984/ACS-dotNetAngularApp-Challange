using ACS_dotNetAngularApp.Business.Abstractions;
using ACS_dotNetAngularApp.Business.Model;
using ACS_dotNetAngularApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace ACS_dotNetAngularApp.API.Tests
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public async Task UserController_Should_Post_Valid_Request()
        {
            string msg= "Successfully added new contact";
            var usr = new ContactUser
            {
                ContactID = 2345,
                FName = "Test1",
                LName = "TestLast",
                DOB = DateTime.Parse("09/02/1984"),
                Email = "hk@hotmail.com",
                Phone = "5678907890"
            };

            var usersManager = new Mock<IContactUser>();
            usersManager.Setup(m => m.NewContactUser(It.IsAny<ContactUser>())).Returns(await Task.FromResult(msg));
            var userController = new UsersController(usersManager.Object);
            var resp = userController.Post(usr);
            var result = resp as OkObjectResult;
            var actualValue = result.Value as string;
            Assert.AreEqual(msg, actualValue);
        }
        
    }
}
