
namespace _06.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender) : 
            base(name, age, gender)
        {
            this.Gender = "Female";
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $@"{this.GetType().Name}
{this.Name} {this.Age} {this.Gender}
{ProduceSound()}";
        }
    }
}
