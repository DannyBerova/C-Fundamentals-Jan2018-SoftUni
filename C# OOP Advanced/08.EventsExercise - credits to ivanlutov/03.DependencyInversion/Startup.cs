namespace _03.DependencyInversion
{
    using System;
    using _03DependencyInversion;

    public class Startup
    {
        public static void Main()
        {
            var calculator = new PrimitiveCalculator(new AdditionStrategy());

            var input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                if (tokens[0] == "mode")
                {
                    switch (tokens[1])
                    {
                        case "+":
                            calculator.changeStrategy(new AdditionStrategy());
                            break;
                        case "-":
                            calculator.changeStrategy(new SubtractionStrategy());
                            break;
                        case "*":
                            calculator.changeStrategy(new MultiplyStrategy());
                            break;
                        case "/":
                            calculator.changeStrategy(new DivideStrategy());
                            break;
                    }
                }
                else
                {
                    var firstOperand = int.Parse(tokens[0]);
                    var secondOperand = int.Parse(tokens[1]);
                    var result = 0;

                    try
                    {
                        result = calculator.performCalculation(firstOperand, secondOperand);
                        Console.WriteLine(result);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }

                input = Console.ReadLine();
            }
        }
    }
}
