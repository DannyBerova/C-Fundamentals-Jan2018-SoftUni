namespace BashSoft.Contracts
{
    using System.Collections.Generic;

    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string username);
        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp);

        ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp);

    }
}
