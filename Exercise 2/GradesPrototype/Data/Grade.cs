﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GradesPrototype.Data
{
    // Types of user
    public enum Role { Teacher, Student };

    // WPF Databinding requires properties

    public class Grade
    {
        public int StudentID { get; set; }

        // Exercise 2: Task 2a: Add validation to the AssessmentDate property
        private string _assesmentDate;
        public string AssessmentDate
        {
            get
            {
                return _assesmentDate;
            }

            set
            {
                DateTime assesmentDate;

                // Verify that the date is valid
                if (DateTime.TryParse(value, out assesmentDate))
                {
                    // Check that the date is no later than current
                    if (assesmentDate > DateTime.Now)
                    {
                        // Throw exception if the date is after the current date
                        throw new ArgumentOutOfRangeException("AssesmentDate", "Assesment date must be on or before current date");
                    }
                    // if the date is valid, save it
                    _assesmentDate = assesmentDate.ToString("d");
                }
                else
                {
                    // Throw exception if the date is not in valid format
                    throw new ArgumentException("AssesmentDate", "Assesment date is not recocnized");
                }
            }
        }

        // Exercise 2: Task 2b: Add validation to the SubjectName property
        private string _subjectName;
        public string SubjectName
        {
            get
            {
               return _subjectName;
            }

            set
            {
                // Check that the specified subject is valid
                if (DataSource.Subjects.Contains(value))
                {
                    // If the subject is valid, save it
                    _subjectName = value;
                }
                else
                {
                    // If the subject is not valid, then throw an exception
                    throw new ArgumentException("SubjectName", "Subject is not recocnized");
                }
            }
        }

        // Exercise 2: Task 2c: Add validation to the Assessment property
        private string _assesment;
        public string Assessment
        {
            get
            {
                return _assesment;
            }
            set
            {
                // Verify that the grade is in the range A+ to E-
                Match matchGrade = Regex.Match(value, @"^[A-E][+-]?$");
                if (matchGrade.Success)
                {
                    _assesment = value;
                }
                else
                {
                    // if the grade is not valid throw an exception
                    throw new ArgumentOutOfRangeException("Assessment", "Assessment grade must be in the range A+ to E-");
                }
            }
        }



        public string Comments { get; set; }
                
        // Constructor to initialize the properties of a new Grade
        public Grade(int studentID, string assessmentDate, string subject, string assessment, string comments)
        {
            StudentID = studentID;
            AssessmentDate = assessmentDate;
            SubjectName = subject;
            Assessment = assessment;
            Comments = comments;
        }

        // Default constructor
        public Grade()
        {
            StudentID = 0;
            AssessmentDate = DateTime.Now.ToString("d");
            SubjectName = "Math";
            Assessment = "A";
            Comments = String.Empty;
        }
    }

    public class Student
    {
        public int StudentID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password { 
            set 
            { 
                _password = value; 
            } 
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }
        
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Constructor to initialize the properties of a new Student
        public Student(int studentID, string userName, string password, string firstName, string lastName, int teacherID)
        {
            StudentID = studentID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            TeacherID = teacherID;
        }

        // Default constructor 
        public Student()
        {
            StudentID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            TeacherID = 0;
        }
    }

    public class Teacher
    {
        public int TeacherID { get; set; }
        public string UserName { get; set; }

        private string _password = Guid.NewGuid().ToString(); // Generate a random password by default
        public string Password
        {
            set
            {
                _password = value;
            }
        }

        public bool VerifyPassword(string pass)
        {
            return (String.Compare(pass, _password) == 0);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }

        // Constructor to initialize the properties of a new Teacher
        public Teacher(int teacherID, string userName, string password, string firstName, string lastName, string className)
        {
            TeacherID = teacherID;
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
        }

        // Default constructor
        public Teacher()
        {
            TeacherID = 0;
            UserName = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            Class = String.Empty;
        }
    }
}
