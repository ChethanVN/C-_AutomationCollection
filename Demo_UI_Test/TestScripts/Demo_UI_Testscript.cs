using Demo_TestFrameWork.ComponentHelper;
using Demo_TestFrameWork.Repository;
using Demo_UI_Test.PageObject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using TestContext = Microsoft.VisualStudio.TestTools.UnitTesting.TestContext;
using NUnit.Framework;
using RelevantCodes.ExtentReports;

namespace Demo_UI_Test.TestScripts
{
    [TestClass]
    [TestFixture]
    [Parallelizable]
    public class Demo_UI_Testscript
    {
        public TestContext TestContext { get; set; }
        private static LogHelper log = new LogHelper();
        
        public Demo_UI_Testscript()
        {
            log.Info("\n ----------------------- \n");
        }

        [TestCategory("POM")]
        [TestMethod]
        [Parallelizable]
        public void NavigateToGoogle()
        {
            log.Info("Starting Test: " + TestContext.TestName);
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest(TestContext.TestName);
            
            log.Info("Verifying the Expected & Actual");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Verifying the Expected & Actual");
            Assert.AreEqual("Google", WindowHelper.GetPageTitle());
        }

        [TestCategory("POM")]
        [TestMethod]
        [Parallelizable]
        public void Test_To_Be_Failed()
        {
            log.Info("Starting Test: " + TestContext.TestName);
            BaseClass.BaseClass.test = BaseClass.BaseClass.report.StartTest(TestContext.TestName);
            Home hp = new Home(ObjectRepository.Driver);
            VacationRentals vr = hp.NavigateToVacationRentals();
            log.Info("Navigated To Vacation Rentals Page");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "Navigated To Vacation Rentals Page");
            
            log.Info("We are intensionally making the test fail here");
            BaseClass.BaseClass.test.Log(LogStatus.Info, "We are intensionally making the test fail here");
            Assert.IsTrue(false);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome.ToString().Equals("Passed"))
            {
                BaseClass.BaseClass.test.Log(LogStatus.Pass, "Test completed and passed");
            }
            else if (TestContext.CurrentTestOutcome.ToString().Equals("Failed"))
            {
                string path = GenericHelper.TakeScreenShotForReport();
                string imagePath = BaseClass.BaseClass.test.AddScreenCapture(path);
                BaseClass.BaseClass.test.Log(LogStatus.Fail, "Test Failed in " + TestContext.TestName, imagePath);
            }
        }
    }


}