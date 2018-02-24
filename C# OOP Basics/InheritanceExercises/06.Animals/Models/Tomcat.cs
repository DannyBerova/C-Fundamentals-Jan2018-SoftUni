namespace _06.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string gender) :
            base(name, age, gender)
        {
            this.Gender = "Male";
        }

        public override string ProduceSound()
        {
            return "MEOW";
        }

        public override string ToString()
        {
            return $@"{this.GetType().Name}
{this.Name} {this.Age} {this.Gender}
{ProduceSound()}";
        }
    }
}