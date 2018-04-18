using System.Linq;
using NUnit.Framework;
using _06.Tweeter;

namespace UnitTests
{
    [TestFixture]
    public class TweeterTests
    {
        private IClient tweeter;

        [SetUp]
        public void TestInit()
        {
            this.tweeter = new TweeterClient();
        }

        [Test]
        public void TestTweetMessageValid()
        {
            this.tweeter.Tweet(new Tweet("Some tweet..."));

            Assert.Pass();
        }

        [Test]
        public void TestTweetEmptyMessageThrowsException()
        {
            Assert.That(() => this.tweeter.Tweet(new Tweet(string.Empty)), Throws.ArgumentNullException);
        }

        [Test]
        public void TestTweetMessageTooLongThrowsException()
        {
            Assert.That(() => this.tweeter.Tweet(new Tweet(new string('o', 256))), Throws.Exception);
        }

        [Test]
        public void TestClientRegistersTweetIncreaseTweetsCount()
        {
            int previousCount = this.tweeter.Tweets.Count();

            this.tweeter.Tweet(new Tweet("Some Tweet..."));

            Assert.That(previousCount + 1, Is.EqualTo(this.tweeter.Tweets.Count));
        }

        [Test]
        public void TestClientReturnsTweetMessageValid()
        {
            string actual = this.tweeter.Tweet(new Tweet("Some Tweet..."));

            Assert.That(actual, Is.EqualTo("Some Tweet..."));
        }

        [Test]
        public void TestMethodShowLastTweetValid()
        {
            for (int i = 1; i < 11; i++)
            {
                var newTweet = new Tweet($"Some Tweet... {i}");
                this.tweeter.Tweet(newTweet);
            }
            string actual = this.tweeter.ShowLastTweet();

            Assert.That(actual, Is.EqualTo("Some Tweet... 10"));
        }

        [Test]
        public void TestMethodShowLastTweetInvalid()
        {
            Assert.That(() => this.tweeter.ShowLastTweet(), Throws.InvalidOperationException);
        }
    }
}
