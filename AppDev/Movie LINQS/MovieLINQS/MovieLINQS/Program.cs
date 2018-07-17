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

            foreach(var Movie in MovieLoader.AllMovies)
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

            Console.WriteLine("Most Movies: ");
            foreach (var Movie in PopRating.Take(1))
            {
                Console.WriteLine($"Rating: {Movie.Key}, Number of Movies: {Movie.Count()}");
            }

            Console.WriteLine("************************************************");

            //Rating, Widest Year Span


            Console.WriteLine("************************************************");

            //Films per Decade over total year range


            Console.WriteLine("************************************************");

            //Unused Ratings in MPAARating Enum


            Console.WriteLine("************************************************");

            //Display All Films, By rating (Ascending), then seperately by title (Ascending Alphabetically)


            Console.WriteLine("************************************************");

            //Group Movies by Number of Words in Title - List by Group with Total


            Console.WriteLine("************************************************");

            //List Total Films with MPAARating of G, PG, PG-13 = total number


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
