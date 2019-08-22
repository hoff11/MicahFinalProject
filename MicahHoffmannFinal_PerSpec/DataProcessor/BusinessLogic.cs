using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataProcessor
{
    public class Student : IStudent
    {
        private int _StudentID;
        private string _StudentName;
        private string _StudentEmail;
        private string _StudentLogin;
        private string _StudentPassword;

        public Student(int StudentID, string StudentName, string StudentEmail, string StudentLogin, string StudentPassword)
        {
            this.StudentID = StudentID;
            this.StudentEmail = StudentEmail;
            this.StudentLogin = StudentLogin;
            this.StudentName = StudentName;
            this.StudentPassword = StudentPassword;
        }
        public int StudentID { get => _StudentID; set => _StudentID = value; }
        public string StudentName { get => _StudentName; set => _StudentName = value; }
        public string StudentEmail { get => _StudentEmail; set => _StudentEmail = value; }
        public string StudentLogin { get => _StudentLogin; set => _StudentLogin = value; }
        public string StudentPassword { get => _StudentPassword; set => _StudentPassword = value; }
    }

    public class StudentProcessor : IStudentProcessor
    {
        private void SetupParameters(ref SqlCommand command)
        {
            SqlParameter param0 = new SqlParameter();
            param0.Direction = System.Data.ParameterDirection.ReturnValue;
            param0.ParameterName = "@RC";
            param0.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(param0);

            SqlParameter param1 = new SqlParameter();
            param1.Direction = System.Data.ParameterDirection.Input;
            param1.ParameterName = "@StudentID";
            param1.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Input;
            param2.ParameterName = "@StudentName";
            param2.SqlDbType = System.Data.SqlDbType.NVarChar;
            param2.Size = 100;
            command.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.Direction = System.Data.ParameterDirection.Input;
            param3.ParameterName = "@StudentEmail";
            param3.SqlDbType = System.Data.SqlDbType.NVarChar;
            param3.Size = 100;
            command.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.Direction = System.Data.ParameterDirection.Input;
            param4.ParameterName = "@StudentLogin";
            param4.SqlDbType = System.Data.SqlDbType.NVarChar;
            param4.Size = 50;
            command.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.Direction = System.Data.ParameterDirection.Input;
            param5.ParameterName = "@StudentPassword";
            param5.SqlDbType = System.Data.SqlDbType.NVarChar;
            param5.Size = 50;
            command.Parameters.Add(param5);

        }
        public int Insert(string ConnectionString, int StudentID, string StudentName, string StudentEmail, string StudentLogin, string StudentPassword)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("pInsStudents", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SetupParameters(ref command);
                command.Parameters["@StudentID"].Value = StudentID;
                command.Parameters["@StudentName"].Value = StudentName;
                command.Parameters["@StudentEmail"].Value = StudentEmail;
                command.Parameters["@StudentLogin"].Value = StudentLogin;
                command.Parameters["@StudentPassword"].Value = StudentPassword;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@RC"].Value < 0) { throw ( new Exception("An internal problem was reported by the stored procedure: " + command.Parameters["@RC"].Value.ToString())); } 
                }
                catch { throw; }
                finally { connection.Close(); }
                return (int)command.Parameters["@RC"].Value;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
