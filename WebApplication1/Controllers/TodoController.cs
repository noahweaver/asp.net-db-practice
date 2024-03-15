using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;

// This is the namespace that our controller is part of
namespace WebApplication1.Controllers
{
    // This attribute specifies the route that the controller will respond to
    [Route("api/[controller]")]
    // This attribute indicates that this class is a controller for handling web API requests
    [ApiController]
    public class TodoController : ControllerBase
    {
        // This is a private variable that will hold configuration information
        private IConfiguration _configuration;

        // This is the constructor for the controller, it gets passed configuration information when the controller is created
        public TodoController(IConfiguration configuration)
        {
            // We store the configuration information in our private variable so we can use it later
            _configuration = configuration;
        }

        // This method responds to GET requests at the route "GetNotes"
        [HttpGet]
        [Route("GetNotes")]
        public JsonResult GetNotes()
        {
            // This is the SQL query that will get all notes
            string query = "select * from dbo.notes";
            // We create a new DataTable to hold the results of the query
            DataTable table = new DataTable();
            // We get the connection string for our database from the configuration
            string sqlDatasource = _configuration.GetConnectionString("todoDBConnection");
            SqlDataReader myReader;

            // We create a new SqlConnection using our connection string
            using (SqlConnection myConnection = new SqlConnection(sqlDatasource))
            {
                // We open the connection to the database
                myConnection.Open();
                // We create a new SqlCommand to execute our query
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // We execute the command and get a SqlDataReader to read the results
                    myReader = myCommand.ExecuteReader();
                    // We load the results into our DataTable
                    table.Load(myReader);
                    // We close the SqlDataReader
                    myReader.Close();
                    // We close the connection to the database
                    myConnection.Close();
                }
            }

            // We return the results as a JsonResult
            return new JsonResult(table);
        }

        // This method responds to GET requests at the route "GetNoteById" and expects an id parameter
        [HttpGet]
        [Route("GetNoteById")]
        public JsonResult GetNoteById(int id)
        {
            // This is the SQL query that will get a note by id
            string query = "select * from dbo.notes where id = @id";
            // We create a new DataTable to hold the results of the query
            DataTable table = new DataTable();
            // We get the connection string for our database from the configuration
            string sqlDatasource = _configuration.GetConnectionString("todoDBConnection");
            SqlDataReader myReader;

            // We create a new SqlConnection using our connection string
            using (SqlConnection myConnection = new SqlConnection(sqlDatasource))
            {
                // We open the connection to the database
                myConnection.Open();
                // We create a new SqlCommand to execute our query
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // We add the id parameter to our command
                    myCommand.Parameters.AddWithValue("@id", id);
                    // We execute the command and get a SqlDataReader to read the results
                    myReader = myCommand.ExecuteReader();
                    // We load the results into our DataTable
                    table.Load(myReader);
                    // We close the SqlDataReader
                    myReader.Close();
                    // We close the connection to the database
                    myConnection.Close();
                }
            }

            // We return the results as a JsonResult
            return new JsonResult(table);
        }

        // This method responds to POST requests at the route "AddNote" and expects a newNote parameter
        [HttpPost]
        [Route("AddNote")]
        public JsonResult AddNote([FromForm] string newNote)
        {
            // This is the SQL query that will add a new note
            string query = "insert into dbo.notes values(@newNote)";
            // We create a new DataTable to hold the results of the query
            DataTable table = new DataTable();
            // We get the connection string for our database from the configuration
            string sqlDatasource = _configuration.GetConnectionString("todoDBConnection");
            SqlDataReader myReader;

            // We create a new SqlConnection using our connection string
            using (SqlConnection myConnection = new SqlConnection(sqlDatasource))
            {
                // We open the connection to the database
                myConnection.Open();
                // We create a new SqlCommand to execute our query
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // We add the newNote parameter to our command
                    myCommand.Parameters.AddWithValue("@newNote", newNote);
                    // We execute the command and get a SqlDataReader to read the results
                    myReader = myCommand.ExecuteReader();
                    // We load the results into our DataTable
                    table.Load(myReader);
                    // We close the SqlDataReader
                    myReader.Close();
                    // We close the connection to the database
                    myConnection.Close();
                }
            }

            // We return a message indicating that the note was added successfully
            return new JsonResult("Added Successfully");
        }

        // This method responds to DELETE requests at the route "DeleteNote" and expects an id parameter
        [HttpDelete]
        [Route("DeleteNote")]
        public JsonResult DeleteNote(int id)
        {
            // This is the SQL query that will delete a note by id
            string query = "delete from dbo.notes where id = @id";
            // We create a new DataTable to hold the results of the query
            DataTable table = new DataTable();
            // We get the connection string for our database from the configuration
            string sqlDatasource = _configuration.GetConnectionString("todoDBConnection");
            SqlDataReader myReader;

            // We create a new SqlConnection using our connection string
            using (SqlConnection myConnection = new SqlConnection(sqlDatasource))
            {
                // We open the connection to the database
                myConnection.Open();
                // We create a new SqlCommand to execute our query
                using (SqlCommand myCommand = new SqlCommand(query, myConnection))
                {
                    // We add the id parameter to our command
                    myCommand.Parameters.AddWithValue("@id", id);
                    // We execute the command and get a SqlDataReader to read the results
                    myReader = myCommand.ExecuteReader();
                    // We load the results into our DataTable
                    table.Load(myReader);
                    // We close the SqlDataReader
                    myReader.Close();
                    // We close the connection to the database
                    myConnection.Close();
                }
            }

            // We return a message indicating that the note was deleted successfully
            return new JsonResult("Deleted Successfully");
        }
    }
}
