﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Enities
{
    [Table("tblTweets")]
    public class Tweet
    {
        public int TweetId { get; set; }    
        public int UserId { get; set; }
        public string TweetText { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
