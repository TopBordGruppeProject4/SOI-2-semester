using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SHI.Model;
using SHI.ViewModel;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly MainViewModel MainViewModel = new MainViewModel();

        [TestInitialize]
        public void Init()
        {
            MainViewModel.WorkerCatalogSingleton.Workers.Add(new Worker("Test", 1, "Test", "01234567", true, "Tester", "Testing"));
        }

        [TestMethod]
        public void TestWorkerExists()
        {
            var check = MainViewModel.WorkerCatalogSingleton.CheckWorker("Tester", "Testing");
            Assert.IsTrue(check);
        }
    }
}
