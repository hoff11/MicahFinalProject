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
}
