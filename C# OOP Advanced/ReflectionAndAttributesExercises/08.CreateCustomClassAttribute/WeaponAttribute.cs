namespace _08.CreateCustomClassAttribute
{
    using System.Linq;
    using System;
    using System.Collections.Generic;
    class WeaponAttribute : Attribute, IWeaponAttribute
    {
        public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>(reviewers);
        }

        public string Author { get; private set; }

        public string Description { get; private set; }

        public IList<string> Reviewers { get; private set; }

        public int Revision { get; private set; }

        public string PrintInfo(string field)
        {
            var joined = (string.Join(", ", this.Reviewers)).ToString();
            var outputResult = (field == "Reviewers") ? ($"Reviewers: {joined}") : string.Empty;

            outputResult = (field == "Description") ? ($"Class description: {this.Description}") : outputResult;

            if (outputResult == string.Empty)
            {
                var fieldToTake = typeof(WeaponAttribute).GetProperties().FirstOrDefault(p => p.Name == field);
                var fieldValue = fieldToTake.GetValue(this).ToString();
                outputResult = $"{field}: {fieldValue}";
            }

            return outputResult;
        }
    }
}
