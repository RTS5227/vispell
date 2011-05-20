using ViSpell.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ViSpellTest
{
    
    
    /// <summary>
    ///This is a test class for HtmlRemovalTest and is intended
    ///to contain all HtmlRemovalTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HtmlRemovalTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for StripTagsCharArray
        ///</summary>
        [TestMethod()]
        public void StripTagsCharArrayTest()
        {
            string source = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = HtmlRemoval.StripTagsCharArray(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StripTagsRegex
        ///</summary>
        [TestMethod()]
        public void StripTagsRegexTest()
        {
            string source = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = HtmlRemoval.StripTagsRegex(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for StripTagsRegexCompiled
        ///</summary>
        [TestMethod()]
        public void StripTagsRegexCompiledTest()
        {
            string source = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = HtmlRemoval.StripTagsRegexCompiled(source);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
