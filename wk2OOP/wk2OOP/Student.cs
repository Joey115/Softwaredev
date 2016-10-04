using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk2OOP
{
    class Student
    {
        int _studentID;
        string _fName, _sName, _course;

        public Student(){ }

        public Student(int ID, string fName, string sName, string course)
        {
            _studentID = ID;
            _fName = fName;
            _sName = sName;
            _course = course;
        }

        public int StudentID
        {
            set
            {
                _studentID = value;
            }
            get
            {
                return _studentID;
            }
        }

        public string FirstName
        {
            set
            {
                _fName = value;
            }
            get
            {
                return _fName;
            }
        }
        public string SurName
        {
            set
            {
                _sName = value;
            }
            get
            {
                return _sName;
            }
        }
        public string Course
        {
            set
            {
                _course = value;
            }
            get
            {
                return _course;
            }
        }

        public void DisplayData()
        {
            Console.WriteLine("Student ID: " + _studentID);
            Console.WriteLine("Student Name : " + _fName + ", " + _sName);
            Console.WriteLine("Student's Course : " + _course);
        }

        ~Student()
        {
            Console.WriteLine("Student details, have been removed");
        }
    }
}
