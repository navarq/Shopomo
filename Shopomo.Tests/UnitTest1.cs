using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopomo.Controllers;

namespace Shopomo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static string validUsername = "JoeBloggs";

        /// <summary>
        /// Checks the Generated Password with the valid username
        /// </summary>
        [TestMethod]
        public void GeneratePasswordTest_ValidUser()
        {
            //Arrange
            PasswordController controller = new PasswordController();

            //Act
            string result = controller.GeneratePassword(validUsername);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(7, result.Length);
        }

        /// <summary>
        /// Checks the Generate Password with an invalid username
        /// </summary>
        [TestMethod]
        public void GeneratePasswordTest_InvalidUser()
        {
            // Arrange 
            PasswordController controller = new PasswordController();

            // Act
            string result = controller.GeneratePassword("InvalidUser");

            // Assert
            Assert.AreEqual("User not found", result);
        }

        /// <summary>
        /// Checks the Validate password action using an invalid username and password
        /// </summary>
        [TestMethod]
        public void ValidatePasswordTest_InvalidUser()
        {
            // Arrange
            PasswordController controller = new PasswordController();

            // Act
            string result = controller.ValidatePassword("InvalidUser", "1234567");

            // Assert
            Assert.AreEqual("User not found", result);
        }

        /// <summary>
        /// Checks the Validate Password action using a valid user and valid password
        /// </summary>
        [TestMethod]
        public void ValidatePasswordTest_ValidPassword()
        {
            // Arrange
            PasswordController controller = new PasswordController();

            // Act
            string password = controller.GeneratePassword(validUsername);
            string result = controller.ValidatePassword(validUsername, password);

            // Assert
            Assert.AreEqual("Login success", result);
        }

        /// <summary>
        /// Checks the Validate Password action to see that valid password can only be used once
        /// </summary>
        [TestMethod]
        public void ValidatePasswordTest_ValidPasswordWorksOnlyOnce()
        {
            // Arrange
            PasswordController controller = new PasswordController();

            // Act
            string password = controller.GeneratePassword(validUsername);

            // use the password for the first time
            string result1 = controller.ValidatePassword(validUsername, password);

            // use the (invalid) password for the second time
            string result2 = controller.ValidatePassword(validUsername, password);

            // Assert
            Assert.AreEqual("Login success", result1);
            Assert.AreEqual("Invalid password", result2);
        }

        /// <summary>
        /// Checks the validatePassword action with a valid user and an invalid password
        /// </summary>
        [TestMethod]
        public void ValidatePasswordTest_InvalidPassword()
        {
            // Arrange
            PasswordController controller = new PasswordController();

            // Act
            string result = controller.ValidatePassword(validUsername, "1234567");

            // Assert
            Assert.AreEqual("Invalid password", result);
        }

        /// <summary>
        /// Checks the Validate action with a valid user and an expired password
        /// </summary>
        [TestMethod]
        public void ValidatePasswordTest_ExpiredPassword()
        {
            // Arrange
            PasswordController generateController = new PasswordController();

            // Act
            string password = generateController.GeneratePassword(validUsername);

            System.Threading.Thread.Sleep(31000);

            string result = generateController.ValidatePassword(validUsername, password);

            // Assert
            Assert.AreEqual("Invalid password", result);
        }
    }
}
