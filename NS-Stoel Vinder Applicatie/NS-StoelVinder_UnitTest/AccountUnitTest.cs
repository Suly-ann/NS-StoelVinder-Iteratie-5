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
        private readonly AccountTestContext loginTestContext = new AccountTestContext();

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestMethod]
        public void TestValidLoginUser()
        {
            Account account = new Account("Emailadres", "Wachtwoord");
            bool testlogin = loginTestContext.LoginContext(account.Email, account.Password);
            Assert.IsTrue(testlogin);
        }

        [TestMethod]
        public void TestNotValidLoginUser()
        {
            Account account = new Account("Email", "Password");
            bool testlogin = loginTestContext.LoginContext(account.Email, account.Password);
            Assert.IsFalse(testlogin);

        }

        [TestMethod]
        public void TestValidRegistration()
        {
            Account account = new Account(1, "Coen", "van de", "Berg", DateTime.Today, "Emailadres", "Wachtwoord");
            bool testlogin = loginTestContext.RegistrationContext(account.ID, account.Firstname, account.Insertion, account.Lastname, account.DateOfBirth, account.Email, account.Password);
            Assert.IsTrue(testlogin);
        }

        [TestMethod]
        public void TestNotValidRegistration()
        {
            Account account = new Account(3, "Lisa", "van", "Dijk", DateTime.Now, "Emailadres", "Wachtwoord");
            bool testlogin = loginTestContext.RegistrationContext(account.ID, account.Firstname, account.Insertion, account.Lastname, account.DateOfBirth, account.Email, account.Password);
            Assert.IsFalse(testlogin);

        }

        [TestMethod]
        public void TestValidDeleteAccount()
        {
            Account account = new Account("Emailadres", "Wachtwoord");
            bool testlogin = loginTestContext.DeleteContext(account.Email, account.Password);
            Assert.IsTrue(testlogin);
        }

        [TestMethod]
        public void TestNotValidDeleteAccount()
        {
            Account account = new Account("Delete", "Account");
            bool testlogin = loginTestContext.DeleteContext(account.Email, account.Password);
            Assert.IsFalse(testlogin);

        }

        [TestMethod]
        public void TestValidResetPassword()
        {
            Account account = new Account("Emailadres", "Wachtwoord");
            bool testlogin = loginTestContext.ResetPasswordContext(account.Email, account.Password);
            Assert.IsTrue(testlogin);
        }

        [TestMethod]
        public void TestNotValidResetPassword()
        {
            Account account = new Account("Wachtwoord", "Password");
            bool testlogin = loginTestContext.ResetPasswordContext(account.Email, account.Password);
            Assert.IsFalse(testlogin);

        }

    }
}
