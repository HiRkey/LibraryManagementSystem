using System;
using LibraryManagementSystem_A2.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
    [TestClass]
    public class BookControllerTests
    {
        [TestMethod]
        public void DeleteUsesDAL()
        {
            //Arrange
            Fakes.FakeBookDAL DAL = new Fakes.FakeBookDAL();
            BooksController controller = new BooksController(DAL);

            //Act
            controller.DeleteConfirmed(5);

            //Assert
            Assert.AreEqual(5, DAL.bookDeleted);

        }
    }
}