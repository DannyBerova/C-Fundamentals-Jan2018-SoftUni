using BashSoft;
using System;
using System.Collections.Generic;
using System.Linq;

class RepositoryFilters
{
    public static void FilterAndTake(Dictionary<string, List<int>> wantedData, string wantedFilter, int studentsToTake)
    {
        if (wantedFilter == "excellent")
        {
            FilterAndTake(wantedData, x => x >= 5, studentsToTake);
        }
        else if (wantedFilter == "average")
        {
            FilterAndTake(wantedData, x => x < 5 && x >= 3.5, studentsToTake);
        }
        else if (wantedFilter == "poor")
        {
            FilterAndTake(wantedData, x => x < 3.5, studentsToTake);
        }
        else
        {
            OutputWriter.DisplayException(ExceptionMessages.InvalidStudentFilter);
        }
    }

    private static void FilterAndTake(Dictionary<string, List<int>> wantedData, Predicate<double> givenFilter,
        int studentsToTake)
    {
        int counterForPrinted = 0;
        foreach (var userName_Points in wantedData)
        {
            if (counterForPrinted == studentsToTake)
            {
                break;
            }

            double averageScore = userName_Points.Value.Average();
            double percentageOfFullfilment = averageScore / 100;
            double averageMark = percentageOfFullfilment * 4 + 2;

            if (givenFilter(averageMark))
            {
                OutputWriter.PrintStudent(userName_Points);
                counterForPrinted++;
            }
        }
    }
}

