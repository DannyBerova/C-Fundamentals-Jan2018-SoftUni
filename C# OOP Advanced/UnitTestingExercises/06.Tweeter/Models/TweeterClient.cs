﻿using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.Tweeter
{
    public class TweeterClient : IClient
    {
        public TweeterClient()
        {
            this.Tweets = new List<ITweet>();
        }

        public IList<ITweet> Tweets { get; set; }

        public string Tweet(ITweet tweet)
        {
            this.Tweets.Add(tweet);
            return this.ShowLastTweet();
        }

        public string ShowLastTweet()
        {
            if (this.Tweets.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.Tweets.Last().Message;
        }
    }
}
