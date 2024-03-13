using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Movies
{
    internal class Movie
    {
        public int movieID;
        public string movieTitle, movieDescription, movieCategory, movieDateDay, movieDateMonth, movieDateYear, movieOrigin;

        public Movie(string movieTitle, string movieDescription, string movieCategory, string movieDateDay, string movieDateMonth, string movieDateYear, string movieOrigin)
        {
            this.movieTitle = movieTitle;
            this.movieDescription = movieDescription;
            this.movieCategory = movieCategory;
            this.movieDateDay = movieDateDay;
            this.movieDateMonth = movieDateMonth;
            this.movieDateYear = movieDateYear;
            this.movieOrigin = movieOrigin;
        }

        public Movie(int movieID, string movieTitle, string movieDescription, string movieCategory, string movieDateDay, string movieDateMonth, string movieDateYear, string movieOrigin)
        {
            this.movieID = movieID;
            this.movieTitle = movieTitle;
            this.movieDescription = movieDescription;
            this.movieCategory = movieCategory;
            this.movieDateDay = movieDateDay;
            this.movieDateMonth = movieDateMonth;
            this.movieDateYear = movieDateYear;
            this.movieOrigin = movieOrigin;
        }

        // Create a method to insert a new movie into the database where the movie is not already in the database and movieDateLaunched = movieDateDay + '/' movieDateMonth + '/' + movieDateYear
        public void InsertMovie()
        {
            // Create a connection to the database
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
            connection.Open();

            // Create a command to check if the movie is already in the database
            SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE Title = @movieTitle", connection);
            command.Parameters.AddWithValue("@movieTitle", movieTitle);

            // Create a reader to read the data from the database
            SqlDataReader reader = command.ExecuteReader();

            // If the movie is not in the database, insert the movie into the database
            if (!reader.Read())
            {
                reader.Close();

                // Create a command to insert the movie into the database
                command = new SqlCommand("INSERT INTO Movies (Title, Description, Category, DateLaunched, Origin) VALUES (@movieTitle, @movieDescription, @movieCategory, @movieDateLaunched, @movieOrigin)", connection);
                command.Parameters.AddWithValue("@movieTitle", movieTitle);
                command.Parameters.AddWithValue("@movieDescription", movieDescription);
                command.Parameters.AddWithValue("@movieCategory", movieCategory);
                command.Parameters.AddWithValue("@movieDateLaunched", movieDateDay + "/" + movieDateMonth + "/" + movieDateYear);
                command.Parameters.AddWithValue("@movieOrigin", movieOrigin);

                // Execute the command
                command.ExecuteNonQuery();
            }

            // Close the connection to the database
            connection.Close();
        }

        // Create a method to update a movie into the database where movieDateLaunched = movieDateDay + '/' movieDateMonth + '/' + movieDateYear
        public void UpdateMovie()
        {
            // Create a connection to the database
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
            connection.Open();

            // Convert the provided date components into a DateTime object
            DateTime movieDateLaunched = new DateTime(int.Parse(movieDateYear), int.Parse(movieDateMonth), int.Parse(movieDateDay));

            // Create a command to update the movie in the database
            SqlCommand command = new SqlCommand("UPDATE Movies SET Title = @movieTitle, Description = @movieDescription, Category = @movieCategory, DateLaunched = @movieDateLaunched, Origin = @movieOrigin WHERE Movie_ID = @movieID", connection);
            command.Parameters.AddWithValue("@movieID", movieID);
            command.Parameters.AddWithValue("@movieTitle", movieTitle);
            command.Parameters.AddWithValue("@movieDescription", movieDescription);
            command.Parameters.AddWithValue("@movieCategory", movieCategory);
            command.Parameters.AddWithValue("@movieDateLaunched", movieDateLaunched);
            command.Parameters.AddWithValue("@movieOrigin", movieOrigin);

            // Execute the command
            command.ExecuteNonQuery();

            // Close the connection to the database
            connection.Close();
        }
    }
}
