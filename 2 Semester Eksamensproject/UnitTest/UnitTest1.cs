using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using SHI.Model;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public WorkerCatalogSingleton WorkerCatalogSingleton { get; set; }
        public CustomerCatalogSingleton CustomerCatalogSingleton { get; set; }
        public RawMaterialCatalogSingleton RawMaterialCatalogSingleton { get; set; }

        [TestInitialize]
        public void Init()
        {
            WorkerCatalogSingleton = WorkerCatalogSingleton.Instance;
            WorkerCatalogSingleton.AddWorker(new Worker("Test", 1, "Test", "01234567", false, "Test", "Test"));

            CustomerCatalogSingleton = CustomerCatalogSingleton.Instance;
            CustomerCatalogSingleton.AddCustomer(new Customer("Test", 1, "Tester", "01234567", "test"));

            RawMaterialCatalogSingleton = RawMaterialCatalogSingleton.Instance;
            RawMaterialCatalogSingleton.AddRawMaterial(new RawMaterial(1, "Test Raw Material", 1, "Test"));
        }

        [TestMethod]
        public void TestWorkerExists()
        {
            var check = WorkerCatalogSingleton.CheckWorker("Tester", "Testing");
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void TestWorkerExists2()
        {
            var check = WorkerCatalogSingleton.CheckWorker("Test", "Test");
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestWorkerAdd()
        {
            const string username = "Testing";
            const string password = "Testing";
            WorkerCatalogSingleton.AddWorker(new Worker("Tester", 2, "Teststrup", "02468246", true, username, password));
            var check = WorkerCatalogSingleton.CheckWorker(username, password);
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestWorkerRemove()
        {
            var worker = WorkerCatalogSingleton.Workers[0];
            WorkerCatalogSingleton.RemoveWorker(worker);
            var check = WorkerCatalogSingleton.CheckWorker(worker.Username, worker.Password);
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void TestCustomerExists()
        {
            var check = CustomerCatalogSingleton.CheckCustomer("Test");
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void TestCustomerExists2()
        {
            var check = CustomerCatalogSingleton.CheckCustomer("Tester");
            Assert.IsTrue(check);
        }

        [TestMethod]
        public void TestRawMaterialExists()
        {
            var check = RawMaterialCatalogSingleton.CheckRawMaterial("Tester");
            Assert.IsFalse(check);
        }

        [TestMethod]
        public void TestRawMaterialExists2()
        {
            var check = RawMaterialCatalogSingleton.CheckRawMaterial("Test");
            Assert.IsTrue(check);
        }
    }
}
