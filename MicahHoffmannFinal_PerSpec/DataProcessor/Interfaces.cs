using System;
using System.Collections.Generic;

namespace DataProcessor
{
    public interface IStudent
    {
        int StudentID { get; set; }
        string StudentName { get; set; }
        string StudentEmail { get; set; }
        string StudentLogin { get; set; }
        string StudentPassword { get; set; }
    }

    public interface IStudentProcessor
    {
        int Insert(string ConnectionString, int StudentID, string StudentName, string StudentEmail, string StudentLogin, string StudentPassword);

    }

    public interface IClass
    {
        int ClassID { get; set; }
        string ClassName { get; set; }
        DateTime ClassDate { get; set; }
        string ClassDescription { get; set; }
    }

    public interface IClassProcessor
    {
    }
}
