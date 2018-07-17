using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFITopMoviesDB;

namespace MovieLINQS
{
    class Program
    {
        //LINQ Comprehension Syntax
        //var evenNums = from int num in nums
        //      where num % 2 == 0
        //      select num;

        //LINQ Extension Syntax
        //var evenNums = nums.Where(num => num % 2 = 0);
        //Where, Select, Orderby, OrderByDescending, GroupBy, Min, Max

        //LINQ Desugarized Syntax
        //var evenNums = Enumerable.Where(nums, Predicate1);
        static void Main(string[] args)
        {

            //Oldest and Newest Movies
            var NewMovie = from Movie in MovieLoader.AllMovies
                           orderby Movie.Year descending
                           select Movie;
            Console.WriteLine("Newest Movie: ");
            foreach (var Movie in NewMovie.Take(1))
            {
                Console.WriteLine($"{Movie.Title,-20} : {Movie.Year,10}");
            }

            var OldMovie = from Movie in MovieLoader.AllMovies
                           orderby Movie.Year ascending
                           select Movie;
            Console.WriteLine("Oldest Movie: ");
            foreach (var Movie in OldMovie.Take(1))
            {
                Console.WriteLine($"{Movie.Title,-20} : {Movie.Year,10}");
            }

            Console.WriteLine("************************************************");

            //Find Classic and New, based on range of year split
            int avg = 0;
            int totYear = 0;

            foreach (var Movie in MovieLoader.AllMovies)
            {
                totYear += Movie.Year;
            }

            avg = totYear / MovieLoader.AllMovies.Count();

            var Classic = from Movie in MovieLoader.AllMovies
                          orderby Movie.Year descending
                          where Movie.Year < avg
                          select Movie;
            Console.WriteLine("All the Classics: ");
            foreach (var Movie in Classic)
            {
                Console.WriteLine($"{Movie.Title,-20} : {Movie.Year,10}");
            }
            Console.WriteLine($"Total Classics: {Classic.Count()}");

            var Newbies = from Movie in MovieLoader.AllMovies
                          orderby Movie.Year descending
                          where Movie.Year >= avg
                          select Movie;
            Console.WriteLine("All the Newbies: ");
            foreach (var Movie in Newbies)
            {
                Console.WriteLine($"{Movie.Title,-20} : {Movie.Year,10}");
            }
            Console.WriteLine($"Total Newbies: {Newbies.Count()}");

            Console.WriteLine("************************************************");

            //More Odd Years or even Years? Answer and Print Totals
            var Evens = from Movie in MovieLoader.AllMovies
                        where Movie.Year % 2 == 0
                        select Movie;

            var Odds = from Movie in MovieLoader.AllMovies
                       where Movie.Year % 2 != 0
                       select Movie;

            Console.WriteLine($"Total Number of Even-Yeared Movies: {Evens.Count()}");
            Console.WriteLine($"Total Number of Odd-Yeared Movies: {Odds.Count()}");

            Console.WriteLine("************************************************");

            //Most Common Year, Qty
            var PopYear = from Movie in MovieLoader.AllMovies
                          group Movie by Movie.Year into g
                          orderby g.Count() descending
                          select g;

            /*
            foreach (var MovieGroup in PopYear)
            {
                Console.WriteLine(MovieGroup.Key);
                foreach (var Movie in MovieGroup)
                {
                    Console.WriteLine(Movie.Title, Movie.Year);
                    Console.WriteLine("");
                }
            }
            */

            Console.WriteLine("Most Movies: ");
            foreach (var Movie in PopYear.Take(1))
            {
                Console.WriteLine($"Year: {Movie.Key}, Number of Movies: {Movie.Count()}");
            }

            Console.WriteLine("************************************************");

            //Most Common Rating, Qty
            var PopRating = from Movie in MovieLoader.AllMovies
                            group Movie by Movie.Rating into g
                            orderby g.Count() descending
                            select g;

            /*
            foreach (var MovieGroup in PopRating)
            {
                Console.WriteLine(MovieGroup.Key);
                foreach (var Movie in MovieGroup)
                {
                    Console.WriteLine(Movie.Title, Movie.Rating);
                    Console.WriteLine("");
                }
            }
            */

            Console.WriteLine("Most Movies per Rating: ");
            foreach (var Movie in PopRating.Take(1))
            {
                Console.WriteLine($"Rating: {Movie.Key}, Number of Movies: {Movie.Count()}");
            }

            Console.WriteLine("************************************************");

            //Shortest Title, Longest Title
            var ShortTitle = from Movie in MovieLoader.AllMovies
                             orderby Movie.Title.Length ascending
                             select Movie;
            foreach (var Movie in ShortTitle.Take(1))
            {
                Console.WriteLine($"Shortest Title: {Movie.Title}");
            }

            var LongTitle = from Movie in MovieLoader.AllMovies
                            orderby Movie.Title.Length descending
                            select Movie;
            foreach (var Movie in LongTitle.Take(1))
            {
                Console.WriteLine($"Longest Title: {Movie.Title}");
            }

            Console.WriteLine("************************************************");

            //Rating, Widest Year Span
            int Distance = 0, LowYear = 0, HighYear = 0, RcrdDist = 0;
            MPAARating LongBoi = MPAARating.NotRated;
            var RatingYears = from Movie in MovieLoader.AllMovies
                              group Movie by Movie.Rating into g
                              select g;
            foreach (var Item in RatingYears)
            {

                foreach (var Movie in Item)
                {
                    if (LowYear == 0 && HighYear == 0)
                    {
                        LowYear = Movie.Year;
                        HighYear = Movie.Year;
                    }
                    else if (LowYear == 0)
                    {
                        LowYear = Movie.Year;
                    }
                    else if (HighYear == 0)
                    {
                        HighYear = Movie.Year;
                    }
                    else if (Movie.Year > HighYear)
                    {
                        HighYear = Movie.Year;
                    }
                    else if (Movie.Year < LowYear)
                    {
                        LowYear = Movie.Year;
                    }

                    Distance = HighYear - LowYear;

                    if (Distance > RcrdDist)
                    {
                        RcrdDist = Distance;
                        LongBoi = Item.Key;
                    }

                }

            }
            Console.WriteLine($"Rating: {LongBoi}, TimeSoan: {RcrdDist}");

            Console.WriteLine("************************************************");

            //Films per Decade over total year range
            var Decades = from Movie in MovieLoader.AllMovies
                          group Movie by Movie.Year / 10 into g
                          orderby g.Key descending
                          select g;
            foreach (var Item in Decades)
            {
                string MyString = Item.Key.ToString();
                Console.WriteLine($"{MyString.Substring(2, 1) + 0}\'s: {Item.Count()}");

            }

            Console.WriteLine("************************************************");

            //Unused Ratings in MPAARating Enum
            bool UsedG = false, UsedNC17 = false, UsedNotRated = false, UsedPG = false, UsedPG13 = false, UsedR = false, UsedUnknown = false, UsedUnrated = false;

            var UsedRatings = from Movie in MovieLoader.AllMovies
                              group Movie by Movie.Rating into g
                              select g;
            foreach (var Item in UsedRatings)
            {
                //Console.WriteLine(Item.Key);
                if (Item.Key == MPAARating.G && UsedG == false)
                {
                    UsedG = true;
                }
                else if (Item.Key == MPAARating.NC17 && UsedNC17 == false)
                {
                    UsedNC17 = true;
                }
                else if (Item.Key == MPAARating.NotRated && UsedNotRated == false)
                {
                    UsedNotRated = true;
                }
                else if (Item.Key == MPAARating.PG && UsedPG == false)
                {
                    UsedPG = true;
                }
                else if (Item.Key == MPAARating.PG13 && UsedPG13 == false)
                {
                    UsedPG13 = true;
                }
                else if (Item.Key == MPAARating.R && UsedR == false)
                {
                    UsedR = true;
                }
                else if (Item.Key == MPAARating.Unknown && UsedUnknown == false)
                {
                    UsedUnknown = true;
                }
                else if (Item.Key == MPAARating.Unrated && UsedUnrated == false)
                {
                    UsedUnrated = true;
                }
            }

            if (UsedG != true)
            {
                Console.WriteLine("The G Rating is never used.");
            }
            if (UsedNC17 != true)
            {
                Console.WriteLine("The NC17 Rating is never used.");
            }
            if (UsedNotRated != true)
            {
                Console.WriteLine("The Not Rated Rating is never used.");
            }
            if (UsedPG != true)
            {
                Console.WriteLine("The PG Rating is never used.");
            }
            if (UsedPG13 != true)
            {
                Console.WriteLine("The PG13 Rating is never used.");
            }
            if (UsedR != true)
            {
                Console.WriteLine("The R Rating is never used.");
            }
            if (UsedUnknown != true)
            {
                Console.WriteLine("The Unknown Rating is never used.");
            }
            if (UsedUnrated != true)
            {
                Console.WriteLine("The Unrated Rating is never used.");
            }

            Console.WriteLine("************************************************");

            //Display All Films, By rating (Ascending), then seperately by title (Ascending Alphabetically)
            var RatingList = from Movie in MovieLoader.AllMovies
                             orderby Movie.Rating ascending
                             select Movie;
            var TitleList = from Movie in MovieLoader.AllMovies
                            orderby Movie.Title descending
                            select Movie;

            Console.WriteLine("Movies Sorted According to Ratings, Descending");
            foreach (var Movie in RatingList)
            {
                Console.WriteLine($"{Movie.Title}, {Movie.Rating}");
            }
            Console.WriteLine("********************************");
            Console.WriteLine("Movies Sorted According to Titles, Ascending");
            foreach (var Movie in TitleList)
            { 
                Console.WriteLine($"{Movie.Title}, {Movie.Rating}");
            }

            Console.WriteLine("************************************************");

            //Group Movies by Number of Words in Title - List by Group with Total
            var TitleLength = from Movie in MovieLoader.AllMovies
                              group Movie by Movie.Title.Length into g
                              select g;
            foreach (var ItemList in TitleLength)
            {
                Console.WriteLine($"Group: {ItemList.Key}, Films: {ItemList.Count()}");
            }

            Console.WriteLine("************************************************");

            //List Total Films with MPAARating of G, PG, PG-13 = total number
            var KidFriendly = from Movie in MovieLoader.AllMovies
                              where Movie.Rating == MPAARating.G || Movie.Rating == MPAARating.PG || Movie.Rating == MPAARating.PG13
                              orderby Movie.Rating ascending
                              select Movie;
            Console.WriteLine($"You could watch {KidFriendly.Count()} Movies. They are: ");
            foreach(var Movie in KidFriendly)
            {
                Console.WriteLine($"{Movie.Title}, Rating: {Movie.Rating}");
            }

            Console.WriteLine("************************************************");

            Console.Write("Press any key to continue...");
            Console.ReadLine();
        }

        //LINQ Comprehension Syntax
        //var evenNums = from int num in nums
        //      where num % 2 == 0
        //      select num;

        //LINQ Extension Syntax
        //var evenNums = nums.Where(num => num % 2 = 0);
        //Where, Select, Orderby, OrderByDescending, GroupBy, Min, Max

        //LINQ Desugarized Syntax
        //var evenNums = Enumerable.Where(nums, Predicate1);

        /* Basically if it's under this line it's from Scott Allens' LINQ Fundamentals Course
        var query = movies.Where(m => m.Year > 2000);
        
        foreach (var movie in query)
        {
            Console.WriteLine(Movie.Title);
        }

         
        */

        /*
        /// <summary>
        /// From Scott Allens' LINQ Fundamentals with C#
        /// </summary>
        /// <param name="path"></param>
        private static void ShowLargeFilesWithLinq(string path)
        {
            var query = from file in new DirectoryInfo(path).getFiles()
                        orderby file.length descending
                        select file;
            foreach (var file in query.Take(5))
            {
                Console.WriteLine($"{file.Name,-20} : {file.Length,10:NO}");
            }
        }
        */
    }
}
