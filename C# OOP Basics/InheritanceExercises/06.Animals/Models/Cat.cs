namespace _06.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, string gender)
            :base(name, age, gender)
        {

        }

        public override string ProduceSound()
        {
            return "Meow meow";
        }

        public override string ToString()
        {
            return $@"{this.GetType().Name}
{this.Name} {this.Age} {this.Gender}
{ProduceSound()}";
        }
    }
}
