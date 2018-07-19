using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateDemo
{
    public delegate void PrintDelegate(string input);

    public static class NewsPublisher
    {
        public static PrintDelegate newsDel;


        public static int num;

        private static string currentHeadline = "Nothing to Report";

        public static void UpdateHeadline(string headline)
        {
            currentHeadline = headline;
            if (newsDel != null)
            {
                newsDel.Invoke(currentHeadline);
            }
        }

    }
    
    public static class TVAnchor
    {
        public static void ReportTheNews(String News)
        {
            Console.WriteLine($"This just in: {News}");
        }
    }

    public static class Blogger
    {
        public static void HashtagPost(string knowledge)
        {
            Console.WriteLine($"The Establishment just said \"{knowledge}\"but that's not the ENTIRE truth, is it? ");
        }
    }

    public static class BurnOut
    {
        public static void HearStuff(String stuff)
        {
            Console.WriteLine("Dude, did you say something?");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //subscribe our listeners to the delegate
            NewsPublisher.newsDel += TVAnchor.ReportTheNews;
            NewsPublisher.newsDel += Blogger.HashtagPost;
            NewsPublisher.newsDel += BurnOut.HearStuff;

            string news = "Playstation Nation is now a sovereign sounty. XBots swear to invade.";

            NewsPublisher.UpdateHeadline(news);
        }
    }
}
