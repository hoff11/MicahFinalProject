using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicahHoffmannFinal_PerSpec.Models
{
    public class Classes
    {
        private int _ClassId;
        private string _ClassName;
        private DateTime _ClassDate;
        private string _ClassDescription;

        public Classes(int ClassId, string ClassName, DateTime ClassDate, string ClassDescription)
        {
            this.ClassId = ClassId;
            this.ClassName = ClassName;
            this.ClassDate = ClassDate;
            this.ClassDescription = ClassDescription;
        }
        public int ClassId { get => _ClassId; set => _ClassId = value; }
        public string ClassName { get => _ClassName; set => _ClassName = value; }
        public DateTime ClassDate { get => _ClassDate; set => _ClassDate = value; }
        public string ClassDescription { get => _ClassDescription; set => _ClassDescription = value; }
    }
}