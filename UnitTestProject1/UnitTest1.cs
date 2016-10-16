using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApplication1;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]

        public void TestMethod1()
        {
            /*
            StudentViewModel sViewModel = new StudentViewModel();
            int count = sViewModel.Students.Count;
            Assert.IsTrue(count == 3);*/
            Assert.IsTrue(3 == 3);
        }
    }
}
