﻿namespace BashSoft
{
    class ExceptionMessages
    {
        public const string DataAlreadyInitializedException = "Data already initialized!";
        public const string DataNotInitializedExceptionMessage = "The data structure must be initialised first in order to make any operations with it.";

        public const string InexistingCourseInDataBase = "The course you are trying to get does not exist in the data base!";
        public const string InexistingStudentInDataBase = "The user name for the student you are trying to get does not exist!";

        public const string InvalidCommand = "The command '{0}' is invalid";
        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";
        public const string InvalidPath = "The folder/file you are trying to access at the current address, does not exist.";
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";
        public const string InvalidTakeQuantityParameter = "The take command expected does not match the format wanted!";

        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certain mismatch.";
        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files and folders.";
        public const string UnauthorizedAccessExceptionMessage = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";

        public const string UnableToGoHigherInPartitionHierarchy = "Cannot go higher in the partition hierarchy";
        public const string UnableToParseNumber = "The sequence you've written is not a valid number.";
    }
}
