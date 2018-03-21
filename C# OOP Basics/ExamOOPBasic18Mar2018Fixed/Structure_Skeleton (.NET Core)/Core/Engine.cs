using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonsAndCodeWizards.Core
{
    class Engine
    {
        private DungeonMaster master;
        private bool isGameOver;

        public Engine()
        {
            this.master = new DungeonMaster();
            this.isGameOver = false;
        }

        public void Run()
        {
            string input;
            while (!isGameOver)
            {
                input = this.ReadInput();
               
                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        this.isGameOver = true;
                        break;
                    }
                    var commandInfo = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    var command = commandInfo[0];
                    var commandArgs = commandInfo.Skip(1).ToArray();

                    ProcessCommand(command, commandArgs);
                }
                catch (Exception e)
                {
                    if (e is ArgumentException)
                    {
                        OutputWriter( $"Parameter Error: {e.Message}");
                        
                    }
                    if (e is InvalidOperationException)
                    {
                        OutputWriter($"Invalid Operation: {e.Message}");
                    }
                }

            }

            OutputWriter("Final stats:");
            OutputWriter(this.master.GetStats());
        }

        private void ProcessCommand(string command, string[] commandArgs)
        {
            switch (command)
            {
                case "JoinParty":
                    OutputWriter(this.master.JoinParty(commandArgs));
                    break;
                case "AddItemToPool":
                    OutputWriter(this.master.AddItemToPool(commandArgs));
                    break;
                case "PickUpItem":
                    OutputWriter(this.master.PickUpItem(commandArgs));
                    break;
                case "UseItem":
                    OutputWriter(this.master.UseItem(commandArgs));
                    break;
                case "UseItemOn":
                    OutputWriter(this.master.UseItemOn(commandArgs));
                    break;
                case "GiveCharacterItem":
                    OutputWriter(this.master.GiveCharacterItem(commandArgs));
                    break;
                case "GetStats":
                    OutputWriter(this.master.GetStats());
                    break;
                case "Attack":
                    OutputWriter(this.master.Attack(commandArgs));
                    break;
                case "Heal":
                    OutputWriter(this.master.Heal(commandArgs));
                    break;
                case "EndTurn":
                    var result = this.master.EndTurn(commandArgs);

                    if (result != String.Empty)
                    {
                        OutputWriter(result);
                    }
                    break;
                case "IsGameOver":
                    isGameOver = this.master.IsGameOver();
                    break;
            }
        }

        private void OutputWriter(string result)
        {
            Console.WriteLine(result);
        }

        private string ReadInput()
        {
            return Console.ReadLine();
        }
    }
}
