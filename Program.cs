using System;
using MySql.Data.MySqlClient;

namespace FormQL_SinhVien
{

    class Program
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Program()
        {
            initilizer();
        }

        private void initilizer()
        {
            server = "localhost";
            database = "quanlysv";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";CharSet=utf8;";

            connection = new MySqlConnection(connectionString);
        }
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Error");
                        break;

                    case 1045:
                        Console.WriteLine("Error");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException)
            {
                Console.WriteLine("Error");
                return false;
            }
        }

        public void Insert(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            string query = "INSERT INTO student (full_name, roll_number) VALUES('"+ student.Name + "' , '"+ student.Rollnumber+ "')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            Student student = new Student("abc","12231");
            p.Insert(student);
        }

       
    }
}
