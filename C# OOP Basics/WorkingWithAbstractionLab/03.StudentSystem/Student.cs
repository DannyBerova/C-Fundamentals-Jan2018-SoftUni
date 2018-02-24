using System;

public class Student
{
    private string name;
    private int age;
    private double grade;

    public double Grade
    {
        get { return grade; }
        set { grade = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Student(string name, int age, double grade)
    {
        this.Name = name;
        this.Age = age;
        this.Grade = grade;
    }

    public override string ToString()
    {

        var gradeComment = GetGradeComment();

        return $"{this.Name} is {this.Age} years old. {gradeComment}";

    }

    private string GetGradeComment()
    {
        if (this.Grade >= 5.00)
        {
            return "Excellent student.";
        }
        else if (this.Grade < 5.00 && this.Grade >= 3.50)
        {
            return "Average student.";
        }
        else
        {
            return "Very nice person.";
        }
    }
}