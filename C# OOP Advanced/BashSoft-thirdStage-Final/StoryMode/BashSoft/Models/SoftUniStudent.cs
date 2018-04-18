using System.Collections.Generic;
using System.Linq;

namespace BashSoft.Models
{
    using Contracts;
    using Exceptions;
    using System;

    public class SoftUniStudent : IStudent
    {
        private string userName;
        private readonly Dictionary<string, ICourse> enrolledCourses;
        private readonly Dictionary<string, double> marksByCourseName;

        public SoftUniStudent(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, ICourse>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get => this.userName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, ICourse> EnrolledCourses => this.enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        public void EnrollInCourse(ICourse course)
        {
            if (this.EnrolledCourses.ContainsKey(course.Name))
            {
                throw new DuplicateEntryInStructureException(this.UserName, course.Name);
            }
            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarkOnCourse(string courseName, params int[] scores)
        {
            if (!this.EnrolledCourses.ContainsKey(courseName))
            {
                throw new CourseNotFoundException();
            }
            if (scores.Length > SoftUniCourse.NumberOfTasksOnExam)
            {
                throw new InvalidNumberOfScoresException();
            }
            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            double percntageOfSolvedExam = scores.Sum() / (double)(SoftUniCourse.NumberOfTasksOnExam * SoftUniCourse.MaxScoreOnExamTask);
            double mark = percntageOfSolvedExam * 4 + 2;

            return mark;
        }

        public int CompareTo(IStudent other) => String.Compare(this.UserName, other.UserName, StringComparison.Ordinal);

        public override string ToString() => this.UserName;
    }
}