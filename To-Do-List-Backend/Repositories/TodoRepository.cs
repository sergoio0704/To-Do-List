using System.Data;
using System.Data.SqlClient;
using To_Do_List_Backend.Domain;

namespace To_Do_List_Backend.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly string _connectionString;

        public TodoRepository( string connectionString )
        {
            _connectionString = connectionString;
        }

        public List<Todo> GetTodos()
        {
            List<Todo> todos = new List<Todo>();
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand cmd = connection.CreateCommand() )
                {
                    cmd.CommandText = "SELECT * FROM [todo]";

                    using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        while ( reader.Read() )
                        {
                            todos.Add( new Todo
                            {
                                Id = Convert.ToInt32( reader["id_todo"] ),
                                Title = Convert.ToString( reader["title"] ),
                                IsDone = Convert.ToBoolean( reader["is_done"] )
                            } );
                        }
                    }
                }
            }

            return todos;
        }

        public int Create( Todo todo )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand cmd = connection.CreateCommand() )
                {
                    cmd.CommandText = "INSERT INTO [todo] (title, is_done) VALUES (@title, @is_done)";
                    cmd.Parameters.Add( "@title", SqlDbType.NVarChar ).Value = todo.Title;
                    cmd.Parameters.Add( "@is_done", SqlDbType.Bit ).Value = todo.IsDone;

                    return Convert.ToInt32( cmd.ExecuteScalar() );
                }
            }
        }

        public void Delete( Todo todo )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand cmd = connection.CreateCommand() )
                {
                    cmd.CommandText = "DELETE FROM [todo] WHERE [id_todo] = @id_todo";
                    cmd.Parameters.Add( "@id_todo", SqlDbType.Int ).Value = todo.Id;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public Todo Get( int id )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand cmd = connection.CreateCommand() )
                {
                    cmd.CommandText = "SELECT * FROM [todo] WHERE [id_todo] = @id_todo";
                    cmd.Parameters.Add( "@id_todo", SqlDbType.Int ).Value = id;

                    using ( SqlDataReader reader = cmd.ExecuteReader() )
                    {
                        if ( reader.Read() )
                        {
                            return new Todo
                            {
                                Id = Convert.ToInt32( reader["id_todo"] ),
                                Title = Convert.ToString( reader["title"] ),
                                IsDone = Convert.ToBoolean( reader["is_done"] )
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public int Update( Todo todo )
        {
            using ( SqlConnection connection = new SqlConnection( _connectionString ) )
            {
                connection.Open();
                using ( SqlCommand cmd = connection.CreateCommand() )
                {
                    cmd.CommandText = @"UPDATE [todo] SET [title] = @title, [is_done] = @is_done
                        WHERE [id_todo] = @id_todo";
                    cmd.Parameters.Add( "@id_todo", SqlDbType.Int ).Value = todo.Id;
                    cmd.Parameters.Add( "@title", SqlDbType.NVarChar ).Value = todo.Title;
                    cmd.Parameters.Add( "@is_done", SqlDbType.Bit ).Value = todo.IsDone;

                    return Convert.ToInt32( cmd.ExecuteScalar() );
                }
            }
        }
    }
}
