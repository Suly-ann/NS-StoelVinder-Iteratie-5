using Microsoft.VisualStudio.TestTools.UnitTesting;
using NS_Stoel_Vinder_Lib.DAL.Contexts.TestContext;
using StoelVinder.lib.BLL;
using StoelVinder.lib.DAL.Models;
using System;

namespace NS_StoelVinder_UnitTest
{
    [TestClass]
    public class AccountUnitTest 
    {
        private AccountRepo accountRepro;

        [TestInitialize]
        public void Setup()
        {
            accountRepro = new AccountRepo(new AccountTestContext());
        }

        [TestMethod]
        public void TestValidLoginUser()
        {
            Account account = new Account("Emailadres", "Persoon123");
            bool testlogin = accountRepro.LogintoTravelplan(account);
            Assert.IsTrue(testlogin);
        }

        [TestMethod]
        public void TestNotValidLoginUser()
        {
            Account account = new Account("Email", "Naam");
            bool testlogin = accountRepro.LogintoTravelplan(account);
            Assert.IsFalse(testlogin);

        }

        [TestMethod]
        public void TestValidRegistration()
        {
            Account account = new Account(1, "Coen", "van de", "Berg", DateTime.Today, "Emailadres", "Persoon123", "Persoon123");
            bool testregistration = accountRepro.Registration(account);
            Assert.IsTrue(testregistration);
        }

        [TestMethod]
        public void TestNotValidRegistration()
        {
            Account account = new Account(2, "Ben", "", "Bakker", DateTime.Now, "ben@hotmail.com", "Ben01", "Ben01");
            bool testregistration = accountRepro.Registration(account);
            Assert.IsFalse(testregistration);

        }

        [TestMethod]
        public void TestValidDeleteAccount()
        {
            Account account = new Account("Emailadres", "Persoon123");
            bool testdelete = accountRepro.DeleteAccount(account);
            Assert.IsTrue(testdelete);
        }

        [TestMethod]
        public void TestNotValidDeleteAccount()
        {
            Account account = new Account("Delete", "Account");
            bool testdelete = accountRepro.DeleteAccount(account);
            Assert.IsFalse(testdelete);

        }

        [TestMethod]
        public void TestValidResetPassword()
        {
            Account account = new Account("Emailadres", "Persoon123");
            bool testreset = accountRepro.ResetPassword(account);
            Assert.IsTrue(testreset);
        }

        [TestMethod]
        public void TestNotValidResetPassword()
        {
            Account account = new Account("Persoon123", "Password");
            bool testreset = accountRepro.ResetPassword(account);
            Assert.IsFalse(testreset);

        }

        [TestMethod]
        public void TestValidCheckEmailAndPassword()
        {
            Account account = new Account("Emailadres", "Persoon123");
            bool testreset = accountRepro.CheckEmailAndPassword(account);
            Assert.IsTrue(testreset);
        }

        [TestMethod]
        public void TestNotValidCheckEmailAndPassword()
        {
            Account account = new Account("Persoon123", "Password");
            bool testreset = accountRepro.CheckEmailAndPassword(account);
            Assert.IsFalse(testreset);

        }

        [TestMethod]
        public void TestValidCheckIfEmailExist()
        {
            Account account = new Account("Emailadres");
            bool testreset = accountRepro.CheckIfEmailExist(account);
            Assert.IsTrue(testreset);
        }

        [TestMethod]
        public void TestNotValidCheckIfEmailExist()
        {
            Account account = new Account("Email");
            bool testreset = accountRepro.CheckIfEmailExist(account);
            Assert.IsFalse(testreset);

        }

    }
}
