using System;
using System.Linq;
using System.Reflection;

public class StartUp
{
    public static void Main()
    {
        var classBlackBoxInt = typeof(BlackBoxInteger);
        var peshoslav = Activator.CreateInstance(classBlackBoxInt, true);
        var methods = classBlackBoxInt.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly);

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var commandArgs = input.Split('_');
            var methodName = commandArgs[0];
            var paramValue = int.Parse(commandArgs[1]);

            MethodInfo currentMethod;
            currentMethod = InvokeMethod(peshoslav, methods, methodName, paramValue);
           var innerValue =  classBlackBoxInt.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).First();
           Console.WriteLine(innerValue.GetValue(peshoslav));
        }
    }

    private static MethodInfo InvokeMethod(object peshoslav, MethodInfo[] methods, string methodName, int paramValue)
    {
        MethodInfo currentMethod = methods.Where(m => m.Name == methodName).First();
        currentMethod.Invoke(peshoslav, new object[] { paramValue });
        return currentMethod;
    }
}

