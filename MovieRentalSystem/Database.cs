using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MovieRentalSystem
{
    public class DBContextHelper
    {
        protected SqlConnection _sqlConnection;
        protected SqlCommand _sqlCommand;
        protected SqlDataAdapter _sqlDataAdapter;
        protected string _connString;

        public DBContextHelper()
        {
            _connString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            _sqlConnection = new SqlConnection(_connString);
        }

        public bool VerifyConn()
        {
            bool Result = false;
            if (_sqlConnection.State != ConnectionState.Open)
            {
                _sqlConnection.Open();
            }
            Result = true;
            _sqlConnection.Close();
            return Result;
        }

        public void CreateCust(string fn, string ln, string add, string ph)
        {
            string Query = "INSERT INTO [tableCustomer] VALUES (@FirstName, @LastName, @Address, @Phone)";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FirstName", fn);
            _sqlCommand.Parameters.AddWithValue("@LastName", ln);
            _sqlCommand.Parameters.AddWithValue("@Address", add);
            _sqlCommand.Parameters.AddWithValue("@Phone", ph);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void UpdateCust(string fn, string ln, string add, string ph, string id)
        {
            string Query = "UPDATE [tableCustomer] SET [FirstName] = @FirstName, [LastName] = @LastName, [Address] = @Address, [Phone] = @Phone WHERE [CustID] = @CustID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@FirstName", fn);
            _sqlCommand.Parameters.AddWithValue("@LastName", ln);
            _sqlCommand.Parameters.AddWithValue("@Address", add);
            _sqlCommand.Parameters.AddWithValue("@Phone", ph);
            _sqlCommand.Parameters.AddWithValue("@CustID", id);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void DeleteCust(string id)
        {
            string Query = "DELETE FROM [tableCustomer] WHERE [CustID] = @CustID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@CustID", id);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public DataTable GetAllCust()
        {
            string Query = "SELECT * FROM [tableCustomer]";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }

        public DataTable GetCustByID(string id)
        {
            string Query = "SELECT * FROM [tableCustomer] WHERE [CustID] = @CustID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@CustID", id);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }

        public DataTable GetMostValuedCust()
        {
            string Query = "SELECT *, ISNULL((SELECT COUNT(RMID) FROM tableRentedMovies WHERE CustIDFK = CustID), 0) AS RentedMovies FROM tableCustomer ORDER BY RentedMovies DESC";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }

        public void CreateMovie(string r, string t, string y, string cost, string copies, string p, string g)
        {
            string Query = "INSERT INTO [tableMovies] VALUES (@Rating, @Title, @Year, @Rental_Cost, @Copies, @Plot, @Genre)";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Rating", r);
            _sqlCommand.Parameters.AddWithValue("@Title", t);
            _sqlCommand.Parameters.AddWithValue("@Year", y);
            _sqlCommand.Parameters.AddWithValue("@Rental_Cost", cost);
            _sqlCommand.Parameters.AddWithValue("@Copies", copies);
            _sqlCommand.Parameters.AddWithValue("@Plot", p);
            _sqlCommand.Parameters.AddWithValue("@Genre", g);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void UpdateMovie(string r, string t, string y, string cost, string copies, string p, string g, string id)
        {
            string Query = "UPDATE [tableMovies] SET [Rating] = @Rating, [Title] = @Title, [Year] = @Year, [Rental_Cost] = @Rental_Cost, [Copies] = @Copies, [Plot] =  @Plot, [Genre] = @Genre WHERE [MovieID] = @MovieID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@Rating", r);
            _sqlCommand.Parameters.AddWithValue("@Title", t);
            _sqlCommand.Parameters.AddWithValue("@Year", y);
            _sqlCommand.Parameters.AddWithValue("@Rental_Cost", cost);
            _sqlCommand.Parameters.AddWithValue("@Copies", copies);
            _sqlCommand.Parameters.AddWithValue("@Plot", p);
            _sqlCommand.Parameters.AddWithValue("@Genre", g);
            _sqlCommand.Parameters.AddWithValue("@MovieID", id);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void DeleteMovie(string id)
        {
            string Query = "DELETE FROM [tableMovies] WHERE [MovieID] = @MovieID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@MovieID", id);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public DataTable GetAllMovies()
        {
            string Query = "SELECT * FROM [tableMovies]";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }

        public DataTable GetMovieByMovieID(string id)
        {
            string Query = "SELECT * FROM [tableMovies] WHERE [MovieID] = @MovieID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@MovieID", id);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }

        public DataTable GetBestSellers()
        {
            string Query = "SELECT *, ISNULL((SELECT COUNT (RMID) FROM tableRentedMovies WHERE MovieIDFK = MovieID), 0) AS TimesRented FROM tableMovies ORDER BY TimesRented DESC";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }

        public void IssueMovie(string mid, string cid, string date)
        {
            string Query = "INSERT INTO [tableRentedMovies] (MovieIDFK, CustIDFK, DateRented) VALUES (@MovieIDFK, @CustIDFK, @DateRented)";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@MovieIDFK", mid);
            _sqlCommand.Parameters.AddWithValue("@CustIDFK", cid);
            _sqlCommand.Parameters.AddWithValue("@DateRented", date);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public void ReturnMovie(string date, string rmid)
        {
            string Query = "UPDATE [tableRentedMovies] SET [DateReturned] = @DateReturned WHERE [RMID] = @RMID";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@DateReturned", date);
            _sqlCommand.Parameters.AddWithValue("@RMID", rmid);
            _sqlConnection.Open();
            _sqlCommand.ExecuteNonQuery();
            _sqlConnection.Close();
        }

        public int CheckCopies(int id)
        {
            string Query = "SELECT (SELECT Copies FROM tableMovies WHERE MovieID = @MovieID) - (SELECT ISNULL(COUNT(MovieIDFK), 0) FROM tableRentedMovies WHERE MovieIDFK = @MovieID AND DateReturned IS NULL)";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            _sqlCommand.Parameters.AddWithValue("@MovieID", id);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return Convert.ToInt32(table.Rows[0][0]);
        }

        public DataTable MoviesToBeReturned()
        {
            string Query = "SELECT RMID, tableCustomer.FirstName, tableCustomer.LastName, tableCustomer.[Address], tableMovies.Title, tableMovies.Rental_Cost, tableRentedMovies.DateRented, tableRentedMovies.DateReturned FROM tableRentedMovies INNER JOIN tableMovies ON tableRentedMovies.MovieIDFK = tableMovies.MovieID INNER JOIN tableCustomer ON tableRentedMovies.CustIDFK = tableCustomer.CustID WHERE tableRentedMovies.DateReturned IS NULL";
            _sqlCommand = new SqlCommand(Query, _sqlConnection);
            DataTable table = new DataTable();
            _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
            _sqlDataAdapter.Fill(table);
            return table;
        }
    }
}
