using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Configuration;

namespace IMDB
{
    class Program
    {
        static void Main(string[] args)
        {
            string sAttr;
            sAttr = ConfigurationManager.AppSettings.Get("dataBaseFile");

            DBConnection dbconn = new DBConnection(sAttr);
            List<string> actors = new List<string>();
            List<string> movies = new List<string>();

            dbconn.connect();

            int userInput = 0;
            do
            {
                userInput = DisplayMenu();
                switch (userInput)
                {
                    case 0:
                        Console.WriteLine("Format Error");
                        break;
                    case 1:
                        Console.Write("Enter Name of Movie: ");
                        var movie = Console.ReadLine();
                        Console.Write("Enter Year of Movie: ");
                        var year = Console.ReadLine();
                        Console.WriteLine(dbconn.addMovie(movie, year));
                        break;
                    case 2:
                        Console.Write("Enter Name of Actor: ");
                        var actor = Console.ReadLine();
                        Console.Write("Enter Age of Actor: ");
                        var age = Console.ReadLine();
                        Console.WriteLine(dbconn.addActor(actor, age));
                        break;
                    case 3:
                        Console.Write("Enter Name of Actor: ");
                        actor = Console.ReadLine();
                        movies.Clear();
                        dbconn.findMovies(actor, ref movies);
                        Console.WriteLine();
                        Console.WriteLine("Movies Featuring " + actor);
                        Console.WriteLine("------------------------------");
                        for (int i = 0; i < movies.Count(); i++)
                        {
                            Console.WriteLine(movies[i]);
                        }
                        if (movies.Count().Equals(0))
                            Console.WriteLine("No Movies found in IMDB");

                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Enter Name of Movie: ");
                        movie = Console.ReadLine();
                        actors.Clear();
                        dbconn.findActors(movie, ref actors);
                        Console.WriteLine();
                        Console.WriteLine("Actors Featured in " + movie);
                        Console.WriteLine("------------------------------");
                        for (int i = 0; i < actors.Count(); i++)
                        {
                            Console.WriteLine(actors[i]);
                        }
                        if (actors.Count().Equals(0))
                            Console.WriteLine("Movie not found in IMDB");

                        Console.WriteLine();
                        break;
                    case 5:
                        Console.Write("Enter Name of Actor: ");
                        actor = Console.ReadLine();
                        Console.Write("Enter Name of Movie: ");
                        movie = Console.ReadLine();
                        Console.WriteLine(dbconn.actorMovieAssociation(actor, movie));
                        break;
                    case 6:
                        Console.Write("Enter Name of Movie to delete: ");
                        movie = Console.ReadLine();
                        Console.WriteLine(dbconn.deleteMovie(movie));
                        break;
                    case 7:
                        Console.Write("Enter Name of Actor to delete: ");
                        actor = Console.ReadLine();
                        Console.WriteLine(dbconn.deleteActor(actor));
                        break;
                    case 8:
                        Console.Write("Enter name of actor to update: ");
                        actor = Console.ReadLine();
                        Console.Write("Enter updated age of actor: ");
                        age = Console.ReadLine();
                        Console.WriteLine(dbconn.updateActorAge(age, actor));
                        break;
                    case 9:
                        Console.Write("Enter name of actor to update: ");
                        actor = Console.ReadLine();
                        Console.Write("Enter updated name of actor: ");
                        var updated_actor = Console.ReadLine();
                        Console.WriteLine(dbconn.updateActorName(actor, updated_actor));
                        break;
                    case 10:
                        Console.Write("Enter name of movie to update: ");
                        movie = Console.ReadLine();
                        Console.Write("Enter updated year of movie: ");
                        year = Console.ReadLine();
                        Console.WriteLine(dbconn.updateMovieYear(movie, year));
                        break;
                    case 11:
                        Console.Write("Enter name of movie to update: ");
                        movie = Console.ReadLine();
                        Console.Write("Enter updated name of movie: ");
                        var updated_movie = Console.ReadLine();
                        Console.WriteLine(dbconn.updateMovieName(movie, updated_movie));
                        break;
                    case 12:
                        movies.Clear();
                        actors.Clear();
                        dbconn.getEntireDB(ref movies, ref actors);
                        Console.WriteLine();
                        Console.WriteLine("Movies in IMDB");
                        Console.WriteLine("--------------");
                        for (int i = 0; i < movies.Count(); i++)
                        {
                            Console.WriteLine(movies[i]);
                        }
                        if (movies.Count().Equals(0))
                            Console.WriteLine("No Movies found in IMDB");

                        Console.WriteLine();
                        Console.WriteLine("Actors in IMDB");
                        Console.WriteLine("--------------");
                        for (int i = 0; i < actors.Count(); i++)
                        {
                            Console.WriteLine(actors[i]);
                        }
                        if (actors.Count().Equals(0))
                            Console.WriteLine("No Actors found in IMDB");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                    case 13:
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }

            } while (userInput != 13);
        }

        static public int DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("IMDB Menu");
            Console.WriteLine("---------");
            Console.WriteLine();
            Console.WriteLine("1.  Add Movie to Database");
            Console.WriteLine("2.  Add Actor to Database");
            Console.WriteLine("3.  Find movies featuring an Actor");
            Console.WriteLine("4.  Find actors featured in a Movie");
            Console.WriteLine("5.  Associate actor to a Movie");
            Console.WriteLine("6.  Delete movie from Database");
            Console.WriteLine("7.  Delete actor from Database");
            Console.WriteLine("8.  Update actor age");
            Console.WriteLine("9.  Update actor name");
            Console.WriteLine("10. Update movie year");
            Console.WriteLine("11. Update movie name");
            Console.WriteLine("12. List DB Contents");
            Console.WriteLine("13. Exit");
            Console.WriteLine();
            Console.Write("Enter Command (1-13): ");

            try
            {
                var result = Console.ReadLine();
                return Convert.ToInt32(result);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
                return 0;
            }
        }
    }
}
