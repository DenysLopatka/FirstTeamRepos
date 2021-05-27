using NUnit.Framework;

namespace FirstTeamProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            var nice = 3;
            nice += 1;
            
            Assert.AreEqual(4, nice);
        }
    }
}