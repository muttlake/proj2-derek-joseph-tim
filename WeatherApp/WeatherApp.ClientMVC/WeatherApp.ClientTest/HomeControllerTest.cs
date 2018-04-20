using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WeatherApp.ClientMVC.Controllers;
using Xunit;

namespace WeatherApp.ClientTest
{
    
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.Index() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void About()
        {
            // Assemble
            HomeController controller = new HomeController();
            // Act
            ViewResult result = controller.About() as ViewResult;
            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void LoginActionReturnsLoginView()
        {
            // Assemble
            HomeController controller = new HomeController();
            // Act
            var result = controller.Login() as RedirectToActionResult;
            // Assert
            Assert.NotNull(result);
            Assert.False(result.Permanent);
            Assert.Equal("Index", result.ViewName);
            //Assert.Equal("Index", result.RouteValues["action"]);
            //Assert.Equal("Login", result.RouteValues["controller"]);
        }

        [Fact]
        public void Error()
        {
            // Assemble
            HomeController controller = new HomeController();
            // Act
            RedirectToPageResult result = controller.Error() as RedirectToPageResult;
            // Assert
            Assert.NotNull(result);
        }
    }
}
