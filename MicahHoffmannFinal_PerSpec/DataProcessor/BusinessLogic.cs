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
                    if ((int)command.Parameters["@RC"].Value < 0) { throw (new Exception("An internal problem was reported by the stored procedure: " + command.Parameters["@RC"].Value.ToString())); }
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
        public List<Student> Select(string ConnectionString)
        {
            try
            {
                string sqlCommand = @"Select StudentID, StudentName, StudentEmail, StudentLogin, StudentPassword From vStudents;";
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                connection.Open();
                System.Data.IDataReader data = command.ExecuteReader();
                List<Student> Students = new List<Student>();
                while (data.Read())
                {
                    Student objRow = new Student((int)data["StudentID"]
                                               , (string)data["StudentName"]
                                               , (string)data["StudentEmail"]
                                               , (string)data["StudentLogin"]
                                               , (string)data["StudentPassword"]);
                    Students.Add(objRow);
                }
                connection.Close();
                return Students;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Login(string ConnectionString, string StudentLogin, string StudentPassword)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("pSelLoginIdByLoginAndPassword", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param0 = new SqlParameter();
                param0.Direction = System.Data.ParameterDirection.ReturnValue;
                param0.ParameterName = "@RC";
                param0.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(param0);

                SqlParameter param4 = new SqlParameter();
                param4.Direction = System.Data.ParameterDirection.Input;
                param4.ParameterName = "@StudentLogin";
                param4.SqlDbType = System.Data.SqlDbType.NVarChar;
                param4.Size = 50;
                command.Parameters.Add(param4);
                command.Parameters["@StudentLogin"].Value = StudentLogin;

                SqlParameter param5 = new SqlParameter();
                param5.Direction = System.Data.ParameterDirection.Input;
                param5.ParameterName = "@StudentPassword";
                param5.SqlDbType = System.Data.SqlDbType.NVarChar;
                param5.Size = 50;
                command.Parameters.Add(param5);
                command.Parameters["@StudentPassword"].Value = StudentPassword;

                SqlParameter param1 = new SqlParameter();
                param1.Direction = System.Data.ParameterDirection.Output;
                param1.ParameterName = "@StudentId";
                param1.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(param1);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@RC"].Value < 0) { throw (new Exception("An internal problem was reported by the stored procedure: " + command.Parameters["@RC"].Value.ToString())); }

                }
                catch { throw; }
                finally { connection.Close(); }
                return (int)command.Parameters["@StudentId"].Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }

    public class Class : IClass
    {
        private int _ClassID;
        private string _ClassName;
        private DateTime _ClassDate;
        private string _ClassDescription;

        public Class(int ClassID, string ClassName, DateTime ClassDate, string ClassDescription)
        {
            this.ClassID = ClassID;
            this.ClassName = ClassName;
            this.ClassDate = ClassDate;
            this.ClassDescription = ClassDescription;
        }
        public int ClassID { get => _ClassID; set => _ClassID = value; }
        public string ClassName { get => _ClassName; set => _ClassName = value; }
        public DateTime ClassDate { get => _ClassDate; set => _ClassDate = value; }
        public string ClassDescription { get => _ClassDescription; set => _ClassDescription = value; }
    }

    public class ClassProcessor
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
            param1.ParameterName = "@ClassId";
            param1.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Input;
            param2.ParameterName = "@StudentId";
            param2.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(param2);

            //SqlParameter param3 = new SqlParameter();
            //param3.Direction = System.Data.ParameterDirection.Input;
            //param3.ParameterName = "@StudentEmail";
            //param3.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param3.Size = 100;
            //command.Parameters.Add(param3);

            //SqlParameter param4 = new SqlParameter();
            //param4.Direction = System.Data.ParameterDirection.Input;
            //param4.ParameterName = "@StudentLogin";
            //param4.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param4.Size = 50;
            //command.Parameters.Add(param4);

            //SqlParameter param5 = new SqlParameter();
            //param5.Direction = System.Data.ParameterDirection.Input;
            //param5.ParameterName = "@StudentPassword";
            //param5.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param5.Size = 50;
            //command.Parameters.Add(param5);

        }
        public int Insert(string ConnectionString, int ClassId, int StudentId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("pInsClassStudents", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SetupParameters(ref command);
                command.Parameters["@ClassId"].Value = ClassId;
                command.Parameters["@StudentId"].Value = StudentId;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    if ((int)command.Parameters["@RC"].Value < 0) { throw (new Exception("An internal problem was reported by the stored procedure: " + command.Parameters["@RC"].Value.ToString())); }
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
        public List<Class> Select(string ConnectionString)
        {
            try
            {
                string sqlCommand = @"Select ClassId, ClassName, ClassDate, ClassDescription From vClasses;";
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand(sqlCommand, connection);
                connection.Open();
                System.Data.IDataReader data = command.ExecuteReader();
                List<Class> classes = new List<Class>();
                while (data.Read())
                {
                    Class objRow = new Class((int)data["ClassId"]
                                               , (string)data["ClassName"]
                                               , (DateTime)data["ClassDate"]
                                               , (string)data["ClassDescription"]);
                    classes.Add(objRow);
                }
                connection.Close();
                return classes;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
    public class StudentClass : IStudentClass
    {
        private int _ClassID;
        private string _ClassName;
        private DateTime _ClassDate;
        private string _ClassDescription;
        private int _StudentID;
        private string _StudentName;
        private string _StudentEmail;

        public StudentClass(int ClassID, string ClassName, DateTime ClassDate, string ClassDescription, int StudentID, string StudentEmail, string StudentName)
        {
            this.ClassID = ClassID;
            this.ClassName = ClassName;
            this.ClassDate = ClassDate;
            this.ClassDescription = ClassDescription;
            this.StudentID = StudentID;
            this.StudentEmail = StudentEmail;
            this.StudentName = StudentName;
        }
        public int ClassID { get => _ClassID; set => _ClassID = value; }
        public string ClassName { get => _ClassName; set => _ClassName = value; }
        public DateTime ClassDate { get => _ClassDate; set => _ClassDate = value; }
        public string ClassDescription { get => _ClassDescription; set => _ClassDescription = value; }
        public int StudentID { get => _StudentID; set => _StudentID = value; }
        public string StudentName { get => _StudentName; set => _StudentName = value; }
        public string StudentEmail { get => _StudentEmail; set => _StudentEmail = value; }

    }

    public class StudentClassProcessor
    {
        private void SetupParameters(ref SqlCommand command)
        {
            //SqlParameter param0 = new SqlParameter();
            //param0.Direction = System.Data.ParameterDirection.ReturnValue;
            //param0.ParameterName = "@RC";
            //param0.SqlDbType = System.Data.SqlDbType.Int;
            //command.Parameters.Add(param0);

            //SqlParameter param1 = new SqlParameter();
            //param1.Direction = System.Data.ParameterDirection.Input;
            //param1.ParameterName = "@ClassId";
            //param1.SqlDbType = System.Data.SqlDbType.Int;
            //command.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.Direction = System.Data.ParameterDirection.Input;
            param2.ParameterName = "@StudentId";
            param2.SqlDbType = System.Data.SqlDbType.Int;
            command.Parameters.Add(param2);

            //SqlParameter param3 = new SqlParameter();
            //param3.Direction = System.Data.ParameterDirection.Input;
            //param3.ParameterName = "@StudentEmail";
            //param3.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param3.Size = 100;
            //command.Parameters.Add(param3);

            //SqlParameter param4 = new SqlParameter();
            //param4.Direction = System.Data.ParameterDirection.Input;
            //param4.ParameterName = "@StudentLogin";
            //param4.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param4.Size = 50;
            //command.Parameters.Add(param4);

            //SqlParameter param5 = new SqlParameter();
            //param5.Direction = System.Data.ParameterDirection.Input;
            //param5.ParameterName = "@StudentPassword";
            //param5.SqlDbType = System.Data.SqlDbType.NVarChar;
            //param5.Size = 50;
            //command.Parameters.Add(param5);

        }
        public List<StudentClass> StudentClasses(string ConnectionString, int StudentId)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand command = new SqlCommand("pSelClassesByStudentId", connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter();
                param1.Direction = System.Data.ParameterDirection.Input;
                param1.ParameterName = "@StudentId";
                param1.SqlDbType = System.Data.SqlDbType.Int;
                command.Parameters.Add(param1);
                command.Parameters["@StudentId"].Value = StudentId;

                connection.Open();
                System.Data.IDataReader data = command.ExecuteReader();
                List<StudentClass> studentClasses = new List<StudentClass>();
                while (data.Read())
                {
                    StudentClass sc = new StudentClass((int)data["ClassId"], (string)data["ClassName"], (DateTime)data["ClassDate"], (string)data["ClassDescription"], (int)data["StudentID"], (string)data["StudentEmail"], (string)data["StudentName"]);
                    studentClasses.Add(sc);
                }
                connection.Close();
                return studentClasses;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
