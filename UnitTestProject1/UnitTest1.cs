using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveBytesProject;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testClass = new Class1();
            byte[] stream = new byte[] { 2, 2, 3, 1, 4, 131, 2, 1, 2, 2, 3, 1, 2, 131 };
            byte[] pattern = new byte[] { 2, 2, 3 };
            byte[] expectedResult = new byte[] { 1, 4, 131, 2, 1, 1, 2, 131 };
            byte[] actualResult = Class1.RemoveBytes(stream, pattern);
            CollectionAssert.AreEqual(expectedResult, actualResult);
            //Assert.AreEqual<byte[]>(expectedResult, actualResult);
        }
        [TestMethod]
        public void OPTest001()
        {
            var testClass = new Class1();
            byte[] stream = new byte[] { 2, 2, 3, 1, 4, 131, 2, 1, 2, 2, 3, 1, 2, 131 };
            byte[] pattern = new byte[] { 2, 2, 3 };
            byte[] expectedResult = new byte[] { 1, 4, 131, 2, 1, 1, 2, 131 };
            byte[] actualResult = Class1.OPRemoveBytes(stream, pattern);
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
