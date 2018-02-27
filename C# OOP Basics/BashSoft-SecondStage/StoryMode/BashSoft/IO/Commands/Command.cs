namespace BashSoft.IO.Commands
{
    using Exceptions;
    using SimpleJudge;
    using System;

    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentsRepository repository;
        private IOManager inputOutputManager;

        public Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.Judge = judge;
            this.Repository = repository;
            this.InputOutputManager = inputOutputManager;
        }

        public string Input
        {
            get => this.input;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        public string[] Data
        {
            get => this.data;
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected Tester Judge
        {
            get => this.judge;
            private set => this.judge = value;
        }

        protected StudentsRepository Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        protected IOManager InputOutputManager
        {
            get => this.inputOutputManager;
            private set => this.inputOutputManager = value;
        }

        public abstract void Execute();
    }
}
