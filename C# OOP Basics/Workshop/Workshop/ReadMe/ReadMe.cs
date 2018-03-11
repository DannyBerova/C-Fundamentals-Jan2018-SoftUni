namespace Forum.App
{
    using System;
    using System.IO;
    using System.Threading;

    public abstract class ReadMe
    {
        public void GetInformation()
        {
            string text = @" Please keep in mind that if you want to clear the simulated database 
  you can do that by clearing the 'data' folder which is located in the 
 'Forum.App' project folder. 
Currently we do NOT have an option for deleting the records with a button but we will add soon.";
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", text));

            string secondtext = @"Do you want me to delete the folder for you ?
 Please write Yes or No";
            Console.WriteLine(secondtext);

            try
            {
                string input = Console.ReadLine();

                Console.CursorVisible = false;
                if (input.ToLower().Equals("yes"))
                {
                    ConsoleSpinner spinner = new ConsoleSpinner();

                    while (true)
                    {

                        for (int i = 0; i < 10; i++)
                        {
                            spinner.Turn("'Data' folder files are being deleted!", 4);
                            Thread.Sleep(400);
                        }

                        DeleteDataFolderFiles();
                        Console.WriteLine("Files are successfully deleted. The program will continue with it's job shortly.");
                        break;
                    }
                }
                else if (input.ToLower().Equals("no"))
                {
                    Console.WriteLine("The program will continue with it's job shortly.");
                }
                else
                {
                    throw new ArgumentException("The input must be either Yes or No");
                }

                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        private void DeleteDataFolderFiles()
        {
            DirectoryInfo myDirInfo = new DirectoryInfo(@"..\data");

            foreach (FileInfo file in myDirInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in myDirInfo.GetDirectories())
            {
                dir.Delete(true);
            }

        }

        public void StartCountDown()
        {
            Console.WriteLine();
            Console.Write("Generating Preview in ");
            for (int timeIndex = 3; timeIndex >= 0; timeIndex--)
            {
                Console.CursorVisible = false;
                Console.CursorLeft = 22;
                Console.Write("{0} seconds ", timeIndex); // Add space to make sure to override previous contents
                Thread.Sleep(1000);
            }
        }
    }
}
