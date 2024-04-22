using Data;
using Enities;
using static System.Net.Mime.MediaTypeNames;

namespace _01.ConfigurationByConvention
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext context = new AppDbContext())
            {
                Console.WriteLine("-------- Users --------");
                foreach (var user in context.Users)
                {
                    Console.WriteLine($"[{user.UserId}] {user.UserName}");
                }
                Console.WriteLine();
                Console.WriteLine("-------- Tweets --------");
                Console.WriteLine();
                foreach (var tweet in context.Tweets)
                {
                    Console.WriteLine($"[{tweet.TweetId}] '{tweet.TweetText}'");
                }
                Console.WriteLine();
                Console.WriteLine("-------- Comments --------");
                Console.WriteLine();
                foreach (var comment in context.Comments)
                {
                    Console.WriteLine($"[{comment.CommentId}] '{comment.CommentText}'");
                }
            }
        }
    }
}
