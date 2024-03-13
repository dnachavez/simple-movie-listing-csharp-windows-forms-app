using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Movies
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            movieList.KeyDown += new KeyEventHandler(movieList_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Disable typing in the movieCategory combobox
            movieCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            // Populate the movieCategory combobox with all the possible categories of a movie
            movieCategory.Items.Add("");
            movieCategory.Items.Add("Action");
            movieCategory.Items.Add("Adventure");
            movieCategory.Items.Add("Comedy");
            movieCategory.Items.Add("Drama");
            movieCategory.Items.Add("Fantasy");
            movieCategory.Items.Add("Horror");
            movieCategory.Items.Add("Mystery");
            movieCategory.Items.Add("Romance");
            movieCategory.Items.Add("Thriller");

            // Initialize the listview columns
            initializeListViewColumns();

            // Display all the movies in the database in the movieList listview
            displayMovies();
        }

        private void initializeListViewColumns()
        {
            // Set the movieList listview to show details
            movieList.View = View.Details;

            // Calculate the width of the columns
            int columndWidth = movieList.Width / 5;

            // Add the columns to the movieList listview that automatically resizes
            movieList.Columns.Add("Movie ID", columndWidth, HorizontalAlignment.Left);
            movieList.Columns.Add("Title", columndWidth, HorizontalAlignment.Left);
            movieList.Columns.Add("Description", columndWidth, HorizontalAlignment.Left);
            movieList.Columns.Add("Category", columndWidth, HorizontalAlignment.Left);
            movieList.Columns.Add("Date Launched", columndWidth, HorizontalAlignment.Left);
            movieList.Columns.Add("Origin", columndWidth, HorizontalAlignment.Left);

            // Adjust the width of the columns to fill the entire width of the listview
            movieList.Columns[movieList.Columns.Count - 1].Width = -2;
        }

        private void saveMovieBtn_Click(object sender, EventArgs e)
        {
            // Check if the user has entered a movie details
            if (movieTitle.Text == "" || movieDescription.Text == "" || movieCategory.Text == "" || movieDateDay.Text == "" || movieDateMonth.Text == "" || movieDateYear.Text == "" || movieOrigin.Text == "")
            {
                MessageBox.Show("Please enter all the movie details", "Error");

                return;
            }
            else
            {
                // Check if the user has entered a valid day, month and year
                if (int.Parse(movieDateDay.Text) < 1 || int.Parse(movieDateDay.Text) > 31 || int.Parse(movieDateMonth.Text) < 1 || int.Parse(movieDateMonth.Text) > 12 || int.Parse(movieDateYear.Text) < 1900)
                {
                    MessageBox.Show("Please enter a valid date", "Error");

                    return;
                }
                else
                {
                    // If the saveMovieBtn button's text is Save, insert the movie into the database
                    if (saveMovieBtn.Text == "Save")
                    {
                        // Create a new movie object
                        Movie movie = new Movie(movieTitle.Text, movieDescription.Text, movieCategory.Text, movieDateDay.Text, movieDateMonth.Text, movieDateYear.Text, movieOrigin.Text);

                        // Insert the movie into the database
                        movie.InsertMovie();

                        // Show a message to the user that the movie has been saved
                        MessageBox.Show("The movie has been saved", "Success");
                    }

                    // If the saveMovieBtn button's text is Update, update the movie in the database
                    else
                    {
                        // Temporary variable to store the movieID converted from string to int
                        int movieID = int.Parse(movieList.SelectedItems[0].Text);

                        // Create a new movie object
                        Movie movie = new Movie(movieID, movieTitle.Text, movieDescription.Text, movieCategory.Text, movieDateDay.Text, movieDateMonth.Text, movieDateYear.Text, movieOrigin.Text);

                        // Update the movie in the database
                        movie.UpdateMovie();

                        // Update the saveMovieBtn button's text to Save
                        saveMovieBtn.Text = "Save";

                        // Show a message to the user that the movie has been updated
                        MessageBox.Show("The movie has been updated", "Success");
                    }

                    // Clear the textboxes
                    movieTitle.Text = "";
                    movieDescription.Text = "";
                    movieCategory.Text = "";
                    movieDateDay.Text = "";
                    movieDateMonth.Text = "";
                    movieDateYear.Text = "";
                    movieOrigin.Text = "";

                    // Refresh the movieList listview
                    displayMovies();
                }
            }
        }

        // Create a method to display all the movies in the database in the movieList listview
        private void displayMovies()
        {
            // Create a connection to the database
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
            connection.Open();

            // Create a command to select all the movies from the database
            SqlCommand command = new SqlCommand("SELECT * FROM Movies", connection);

            // Create a reader to read the data from the database
            SqlDataReader reader = command.ExecuteReader();

            // Clear the movieList listview
            movieList.Items.Clear();

            // Add the movies to the movieList listview
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["Movie_ID"].ToString());
                item.SubItems.Add(reader["Title"].ToString());
                item.SubItems.Add(reader["Description"].ToString());
                item.SubItems.Add(reader["Category"].ToString());
                DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                item.SubItems.Add(dateLaunched.ToString("d"));
                item.SubItems.Add(reader["Origin"].ToString());
                movieList.Items.Add(item);
            }

            // Close the connection to the database
            connection.Close();
        }

        // Create a method to display the details of a movie in a messagebox when the user double clicks a movie from the movieList listview
        private void movieList_DoubleClick(object sender, EventArgs e)
        {
            // Create a connection to the database
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
            connection.Open();

            // Create a command to select the movie from the database
            SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE Movie_ID = @movieID", connection);
            command.Parameters.AddWithValue("@movieID", movieList.SelectedItems[0].Text);

            // Create a reader to read the data from the database
            SqlDataReader reader = command.ExecuteReader();

            // Display the details of the movie in a messagebox
            if (reader.Read())
            {
                DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                MessageBox.Show("Movie ID: " + reader["Movie_ID"].ToString() + "\nTitle: " + reader["Title"].ToString() + "\nDescription: " + reader["Description"].ToString() + "\nCategory: " + reader["Category"].ToString() + "\nDate Launched: " + dateLaunched.ToString("d") + "\nOrigin: " + reader["Origin"].ToString(), "Movie Detail");
            }

            // Close the connection to the database
            connection.Close();
        }

        private void movieList_KeyDown(object sender, KeyEventArgs e)
        {
            // If the user presses the enter key, populate the textboxes and combobox with the details of the selected movie from the movieList listview
            if (e.KeyCode == Keys.Enter)
            {
                movieTitle.Text = movieList.SelectedItems[0].SubItems[1].Text;
                movieDescription.Text = movieList.SelectedItems[0].SubItems[2].Text;
                movieCategory.Text = movieList.SelectedItems[0].SubItems[3].Text;
                string[] dateLaunched = movieList.SelectedItems[0].SubItems[4].Text.Split('/');
                movieDateDay.Text = dateLaunched[0];
                movieDateMonth.Text = dateLaunched[1];
                movieDateYear.Text = dateLaunched[2];
                movieOrigin.Text = movieList.SelectedItems[0].SubItems[5].Text;

                // Update the saveMovieBtn button's text to Update
                saveMovieBtn.Text = "Update";
            }

            // If the user presses the delete key, delete the selected movie from the movieList listview and the database
            if (e.KeyCode == Keys.Delete)
            {
                // Show a prompt to the user to confirm the deletion of the movie
                DialogResult result = MessageBox.Show("Are you sure you want to delete the movie?", "Delete Movie", MessageBoxButtons.YesNo);

                // If the user presses the yes button, delete the movie from the movieList listview and the database
                if (result == DialogResult.Yes)
                {
                    // Create a connection to the database
                    SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
                    connection.Open();

                    // Create a command to delete the movie from the database
                    SqlCommand command = new SqlCommand("DELETE FROM Movies WHERE Movie_ID = @movieID", connection);
                    command.Parameters.AddWithValue("@movieID", movieList.SelectedItems[0].Text);

                    // Execute the command
                    command.ExecuteNonQuery();

                    // Close the connection to the database
                    connection.Close();

                    // Refresh the movieList listview
                    displayMovies();
                }
            }
        }

        private void searchMovieBtn_Click(object sender, EventArgs e)
        {
            // If more than one textbox or combobox has been filled, display a message to the user that only one textbox or combobox should be filled
            if ((movieTitle.Text != "" && movieDescription.Text != "") || (movieTitle.Text != "" && movieCategory.Text != "") || (movieTitle.Text != "" && movieDateDay.Text != "" && movieDateMonth.Text != "" && movieDateYear.Text != "") || (movieTitle.Text != "" && movieOrigin.Text != "") || (movieDescription.Text != "" && movieCategory.Text != "") || (movieDescription.Text != "" && movieDateDay.Text != "" && movieDateMonth.Text != "" && movieDateYear.Text != "") || (movieDescription.Text != "" && movieOrigin.Text != "") || (movieCategory.Text != "" && movieDateDay.Text != "" && movieDateMonth.Text != "" && movieDateYear.Text != "") || (movieCategory.Text != "" && movieOrigin.Text != "") || (movieDateDay.Text != "" && movieDateMonth.Text != "" && movieDateYear.Text != "" && movieOrigin.Text != ""))
            {
                MessageBox.Show("Please fill only one textbox or combobox", "Error");

                // Refresh the movieList listview
                displayMovies();

                return;
            }

            // If the movieTitle textbox is not empty, search for the movie in the database using Title and display the details of the movie in the movieList listview
            if (movieTitle.Text != "")
            {
                // Create a connection to the database
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
                connection.Open();

                // Create a command to select the movie from the database
                SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE Title = @movieTitle", connection);
                command.Parameters.AddWithValue("@movieTitle", movieTitle.Text);

                // Create a reader to read the data from the database
                SqlDataReader reader = command.ExecuteReader();

                // Clear the movieList listview
                movieList.Items.Clear();

                // Add the movie to the movieList listview
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Movie_ID"].ToString());
                    item.SubItems.Add(reader["Title"].ToString());
                    item.SubItems.Add(reader["Description"].ToString());
                    item.SubItems.Add(reader["Category"].ToString());
                    DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                    item.SubItems.Add(dateLaunched.ToString("d"));
                    item.SubItems.Add(reader["Origin"].ToString());
                    movieList.Items.Add(item);
                }

                // Close the connection to the database
                connection.Close();
            }
            
            // If the movieDescription textbox is not empty, search for the movie in the database using Description and display the details of the movie in the movieList listview
            else if (movieDescription.Text != "")
            {
                // Create a connection to the database
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
                connection.Open();

                // Create a command to select the movie from the database
                SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE Description LIKE @movieDescription", connection);
                command.Parameters.AddWithValue("@movieDescription", "%" + movieDescription.Text + "%");

                // Create a reader to read the data from the database
                SqlDataReader reader = command.ExecuteReader();

                // Clear the movieList listview
                movieList.Items.Clear();

                // Add the movie to the movieList listview
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Movie_ID"].ToString());
                    item.SubItems.Add(reader["Title"].ToString());
                    item.SubItems.Add(reader["Description"].ToString());
                    item.SubItems.Add(reader["Category"].ToString());
                    DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                    item.SubItems.Add(dateLaunched.ToString("d"));
                    item.SubItems.Add(reader["Origin"].ToString());
                    movieList.Items.Add(item);
                }

                // Close the connection to the database
                connection.Close();
            }

            // If the movieCategory combobox is not empty, search for the movie in the database using Category and display the details of the movie in the movieList listview
            else if (movieCategory.Text != "")
            {
                // Create a connection to the database
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
                connection.Open();

                // Create a command to select the movie from the database
                SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE Category = @movieCategory", connection);
                command.Parameters.AddWithValue("@movieCategory", movieCategory.Text);

                // Create a reader to read the data from the database
                SqlDataReader reader = command.ExecuteReader();

                // Clear the movieList listview
                movieList.Items.Clear();

                // Add the movie to the movieList listview
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Movie_ID"].ToString());
                    item.SubItems.Add(reader["Title"].ToString());
                    item.SubItems.Add(reader["Description"].ToString());
                    item.SubItems.Add(reader["Category"].ToString());
                    DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                    item.SubItems.Add(dateLaunched.ToString("d"));
                    item.SubItems.Add(reader["Origin"].ToString());
                    movieList.Items.Add(item);
                }

                // Close the connection to the database
                connection.Close();
            }

            // If the movieDateDay, movieDateMonth and movieDateYear textboxes are not empty, search for the movie in the database using DateLaunched and display the details of the movie in the movieList listview
            else if (movieDateDay.Text != "" && movieDateMonth.Text != "" && movieDateYear.Text != "")
            {
                // Create a connection to the database
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
                connection.Open();

                // Create a command to select the movie from the database
                SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE DateLaunched = @movieDateLaunched", connection);
                command.Parameters.AddWithValue("@movieDateLaunched", movieDateDay.Text + "/" + movieDateMonth.Text + "/" + movieDateYear.Text);

                // Create a reader to read the data from the database
                SqlDataReader reader = command.ExecuteReader();

                // Clear the movieList listview
                movieList.Items.Clear();

                // Add the movie to the movieList listview
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Movie_ID"].ToString());
                    item.SubItems.Add(reader["Title"].ToString());
                    item.SubItems.Add(reader["Description"].ToString());
                    item.SubItems.Add(reader["Category"].ToString());
                    DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                    item.SubItems.Add(dateLaunched.ToString("d"));
                    item.SubItems.Add(reader["Origin"].ToString());
                    movieList.Items.Add(item);
                }

                // Close the connection to the database
                connection.Close();
            }

            // If the movieOrigin textbox is not empty, search for the movie in the database using Origin and display the details of the movie in the movieList listview
            else if (movieOrigin.Text != "")
            {
                // Create a connection to the database
                SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\DAN\\source\\repos\\Movies\\Movies\\Database1.mdf;Initial Catalog=Movies;Integrated Security=True");
                connection.Open();

                // Create a command to select the movie from the database
                SqlCommand command = new SqlCommand("SELECT * FROM Movies WHERE Origin = @movieOrigin", connection);
                command.Parameters.AddWithValue("@movieOrigin", movieOrigin.Text);

                // Create a reader to read the data from the database
                SqlDataReader reader = command.ExecuteReader();

                // Clear the movieList listview
                movieList.Items.Clear();

                // Add the movie to the movieList listview
                while (reader.Read())
                {
                    ListViewItem item = new ListViewItem(reader["Movie_ID"].ToString());
                    item.SubItems.Add(reader["Title"].ToString());
                    item.SubItems.Add(reader["Description"].ToString());
                    item.SubItems.Add(reader["Category"].ToString());
                    DateTime dateLaunched = Convert.ToDateTime(reader["DateLaunched"]);
                    item.SubItems.Add(dateLaunched.ToString("d"));
                    item.SubItems.Add(reader["Origin"].ToString());
                    movieList.Items.Add(item);
                }

                // Close the connection to the database
                connection.Close();
            }

            // If no textbox or combobox has been filled, display a message to the user that a textbox or combobox should be filled
            else
            {
                MessageBox.Show("Please fill a textbox or combobox", "Error");

                // Refresh the movieList listview
                displayMovies();

                return;
            }

            // Clear the textboxes
            movieTitle.Text = "";
            movieDescription.Text = "";
            movieCategory.Text = "";
            movieDateDay.Text = "";
            movieDateMonth.Text = "";
            movieDateYear.Text = "";
            movieOrigin.Text = "";

            // If the movieList listview is empty, display a message to the user that the movie is not in the database
            if (movieList.Items.Count == 0)
            {
                MessageBox.Show("The movie is not in the database", "Error");

                // Refresh the movieList listview
                displayMovies();

                return;
            }
        }
    }
}
