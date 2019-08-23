using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicahHoffmannFinal_PerSpec.Models
{
    public class StudentClass
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

}