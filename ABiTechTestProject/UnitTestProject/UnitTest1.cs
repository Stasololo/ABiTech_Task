using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ABiTechTestProject.Interface;
using ABiTechTestProject.Models;
using ABiTechTestProject.Managers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        Mock<IRepository<Status>> _statusRepository;
        public UnitTest1()
        {
            _statusRepository = new Mock<IRepository<Status>> ();
            _statusRepository.Setup(c => c.Get()).Returns(new[] 
            {
                new Status() { Id = 1, Title = "Open"},
                new Status() { Id = 2, Title = "Close" },
                new Status() { Id = 3, Title = "Active" }
            });
        }

        [TestMethod]
        public void TestMethod1()
        {
            IValidationManager<Status> validation = new StatusValidationManager(_statusRepository.Object);
            var result1 = validation.CheckForUniqueByName(new Status()
            {
                Id = 1,
                Title = "Open"
            });

            var result2 = validation.CheckForUniqueByName(new Status()
            {
                Id = 1,
                Title = "Delete"
            });

            Assert.AreEqual(result1, false);
            Assert.AreEqual(result2, true);
        }
    }
}
