using ViSpell;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Drawing;

namespace ViSpellTest
{
    
    
    /// <summary>
    ///This is a test class for SpellCheckerEngineTest and is intended
    ///to contain all SpellCheckerEngineTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SpellCheckerEngineTest
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
        ///A test for Run
        ///</summary>
        [TestMethod()]
        public void RunTest()
        {
            SpellCheckerEngine_Accessor target = new SpellCheckerEngine_Accessor(); // TODO: Initialize to an appropriate value
            string pSourceText = string.Empty; // TODO: Initialize to an appropriate value
            CheckingResult expected = null; // TODO: Initialize to an appropriate value
            CheckingResult actual;
            actual = target.Run(pSourceText);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for WrapStrongWord
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ViSpell.exe")]
        public void WrapStrongWordTest()
        {
            SpellCheckerEngine_Accessor target = new SpellCheckerEngine_Accessor(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;

            // check string empty
            actual = target.WrapStrongWord(s);
            Assert.AreEqual(expected, actual);

            // check null
            s = null;
            expected = null;
            actual = target.WrapStrongWord(s);
            Assert.AreEqual(expected, actual);
            
            // check normal
            s = "hello";
            expected = "<strong>hello</strong>";
            actual = target.WrapStrongWord(s);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for WrapColorWord
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ViSpell.exe")]
        public void WrapColorWordTest()
        {
            SpellCheckerEngine_Accessor target = new SpellCheckerEngine_Accessor(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            Color c = new Color(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;

            // checked string empty
            actual = target.WrapColorWord(s, c);
            Assert.AreEqual(expected, actual);            

            // check null
            s = null;
            expected = null;
            actual = target.WrapColorWord(s, c);
            Assert.AreEqual(expected, actual);

            // normal
            s = "hello";
            expected = "<span style='color:Blue;'>hello</span>";
            c = Color.Blue;
            actual = target.WrapColorWord(s, c);
            Assert.AreEqual(expected.ToLower(), actual.ToLower());
        }

        /// <summary>
        ///A test for NormalizeWord
        ///</summary>
        [TestMethod()]
        [DeploymentItem("ViSpell.exe")]
        public void NormalizeWordTest()
        {
            SpellCheckerEngine_Accessor target = new SpellCheckerEngine_Accessor(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.NormalizeWord(s);
            Assert.AreEqual(expected, actual);

            s = null;
            expected = null;
            actual = target.NormalizeWord(s);
            Assert.AreEqual(expected, actual);

            s = "<div><p>hello     \n </p><div>  world </div></div>";
            expected = "hello world ";
            actual = target.NormalizeWord(s);
            Assert.AreEqual(expected, actual);
        }
    }
}
