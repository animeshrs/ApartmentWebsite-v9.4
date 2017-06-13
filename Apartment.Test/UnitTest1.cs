using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Apartment.Security;

namespace Apartment.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
           
        }

        [TestMethod]
        public void TestMethod2()
        {
            //HelperClass.GetUserList();
            HelperClass hp = new HelperClass();
            hp.GetRolesByUser("Animesh");
        }
    }
}
