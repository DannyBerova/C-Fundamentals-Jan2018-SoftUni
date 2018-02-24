namespace _06.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
           return "Woof!";
        }

        public override string ToString()
        {
            return $@"{this.GetType().Name}
{this.Name} {this.Age} {this.Gender}
{ProduceSound()}";
        }
    }
}
