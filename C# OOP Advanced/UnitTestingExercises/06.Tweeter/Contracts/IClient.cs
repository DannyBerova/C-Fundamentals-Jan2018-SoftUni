using System.Collections.Generic;

namespace _06.Tweeter
{
    public interface IClient
    {
        IList<ITweet> Tweets { get; set; }

        string ShowLastTweet();
        string Tweet(ITweet tweet);
    }
}