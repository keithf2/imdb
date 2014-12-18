using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace IMDB
{
    class DBConnection
    {
        string _dbfile;
        string createTableMovies = @"CREATE TABLE IF NOT EXISTS [Movies] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [movie] NVARCHAR(2048)  NULL,
                          [year] VARCHAR(2048)  NULL
                          )";

        string createTableActors = @"CREATE TABLE IF NOT EXISTS [Actors] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [actor] NVARCHAR(2048)  NULL,
                          [age] VARCHAR(2048)  NULL
                          )";

        string createTableMovieAttributes = @"CREATE TABLE IF NOT EXISTS [MovieAttributes] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [movie] NVARCHAR(2048)  NULL,
                          [actor] VARCHAR(2048)  NULL
                          )";

        System.Data.SQLite.SQLiteConnection con;
        System.Data.SQLite.SQLiteCommand com;
        List<string> movies = new List<string>();
        List<string> actors = new List<string>();

        public DBConnection(string dbfile)
        {
            _dbfile = dbfile;
        }

        public DBConnection() { }

        public void setDBFileName(string dbfilename)
        {
            _dbfile = dbfilename;
        }

        public void connect()
        {
            if (!File.Exists(_dbfile))
                System.Data.SQLite.SQLiteConnection.CreateFile(_dbfile);

            con = new System.Data.SQLite.SQLiteConnection("data source=" + _dbfile);

            com = new System.Data.SQLite.SQLiteCommand(con);

            con.Open();
            com.CommandText = createTableMovies;
            com.ExecuteNonQuery();

            com.CommandText = createTableActors;
            com.ExecuteNonQuery();

            com.CommandText = createTableMovieAttributes;
            com.ExecuteNonQuery();
        }

        public void addActor(string actor, string age)
        {
            // search DB to see if actor exists
            // update DB accordingly
            actor = actor.Trim();
            com.CommandText = "Select * FROM Actors WHERE actor =  '" + actor + "'";
            com.ExecuteNonQuery();

            actors.Clear();
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["actor"].ToString()))
                        actors.Add(reader["actor"].ToString());
                }
            }
            if (actors.Count().Equals(0))
            {
                // Add entry into imdb 
                com.CommandText = "INSERT INTO Actors (actor,age) Values ('" + actor + "', '" + age + "')";
                com.ExecuteNonQuery();
            }
        }

        public void addMovie(string movie, string year)
        {
            // search DB to see if movie exists
            // update DB accordingly
            movie = movie.Trim();
            com.CommandText = "Select * FROM Movies WHERE movie =  '" + movie + "'";
            com.ExecuteNonQuery();

            movies.Clear();
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["movie"].ToString()))
                        movies.Add(reader["movie"].ToString());
                }
            }
            if (movies.Count().Equals(0))
            {
                // Add entry into imdb
                com.CommandText = "INSERT INTO Movies (movie,year) Values ('" + movie + "', '" + year + "')";
                com.ExecuteNonQuery();
            }
        }

        public void deleteActor(string actor)
        {
            //delete Actor if they exist
            actor = actor.Trim();
            com.CommandText = "Delete FROM Actors WHERE actor = '" + actor + "'";
            com.ExecuteNonQuery();
            com.CommandText = "Delete FROM MovieAttributes WHERE actor = '" + actor + "'";
            com.ExecuteNonQuery();
        }

        public void findMovies(string actor, ref List<string> movie_list)
        {
            actor = actor.TrimEnd();
            com.CommandText = "Select * FROM MovieAttributes WHERE actor =  '" + actor + "'";
            com.ExecuteNonQuery();

            movies.Clear();
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["movie"].ToString()))
                        movies.Add(reader["movie"].ToString());
                }
            }
            movie_list = movies;
        }

        public void findActors(string movie, ref List<string> actor_list)
        {
            movie = movie.Trim();
            com.CommandText = "Select * FROM MovieAttributes WHERE movie =  '" + movie + "'";
            com.ExecuteNonQuery();

            actors.Clear();
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["actor"].ToString()))
                        actors.Add(reader["actor"].ToString());
                }
            }
            actor_list = actors;
        }

        public void deleteMovie(string movie)
        {
            // delete movie if it exists.
            movie = movie.Trim();
            com.CommandText = "Delete FROM Movies WHERE movie = '" + movie + "'";
            com.ExecuteNonQuery();
            com.CommandText = "Delete FROM MovieAttributes WHERE movie = '" + movie + "'";
            com.ExecuteNonQuery();
        }

        public string actorMovieAssociation(string actor, string movie)
        {
            movie = movie.Trim();
            actor = actor.Trim();
            string status = "success";
            // if actor exists and movie exists, and not already associated, associate.
            movies.Clear();
            com.CommandText = "Select * FROM MovieAttributes WHERE movie = '" + movie + "' AND actor = '" + actor + "'";
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["movie"].ToString()))
                        movies.Add(reader["movie"].ToString());
                }
            }
            if (!movies.Count().Equals(0))
            {
                status = "( " + movie + " : " + actor + " ) association already exists";
                return status;
            }

            com.CommandText = "Select movie FROM Movies WHERE movie = '" + movie + "'";

            movies.Clear();
            actors.Clear();
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["movie"].ToString()))
                        movies.Add(reader["movie"].ToString());
                }
            }

            com.CommandText = "Select actor FROM Actors WHERE actor = '" + actor + "'";
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["actor"].ToString()))
                        actors.Add(reader["actor"].ToString());
                }
            }

            if (!movies.Count().Equals(0)) //movie found in imdb
            {
                if (!actors.Count().Equals(0)) //actor found in imdb
                {
                    //make the association
                    com.CommandText = "INSERT INTO MovieAttributes (movie,actor) Values ('" + movie + "', '" + actor + "')";
                    com.ExecuteNonQuery();
                }
                else
                    status = "error, actor not found";
            }
            else
                status = "error, movie not found";

            return status;
        }

        public void getEntireDB(ref List<string> movie_list, ref List<string> actor_list)
        {
            com.CommandText = "Select * FROM Movies";

            movies.Clear();
            actors.Clear();
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["movie"].ToString()))
                    {
                        movies.Add(reader["movie"].ToString());
                    }
                }
            }

            com.CommandText = "Select * FROM Actors";
            using (System.Data.SQLite.SQLiteDataReader reader = com.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!String.IsNullOrEmpty(reader["actor"].ToString()))
                    {
                        actors.Add(reader["actor"].ToString());
                    }
                }
            }

            movie_list = movies.Distinct().ToList();
            actor_list = actors.Distinct().ToList();
        }
    }
}
