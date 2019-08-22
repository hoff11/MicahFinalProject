using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicahHoffmannFinal_PerSpec.Models
{
    public class Student
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
}