using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflector.ToFile("Car", "car");
            Reflector.ToFile("Flower", "flower");

            Reflector.GetPublicMethods("Car");
            Reflector.GetPublicMethods("Flower");

            Reflector.GetField("Car");
            Reflector.GetField("Flower");

            Reflector.GetInterfaces("Car");
            Reflector.GetInterfaces("Flower");

            Reflector.GetMethodsByParam("Car", "System.String");
            Reflector.GetMethodsByParam("Flower", "System.String");

            Reflector.CallMethodFromFile("Car", "show");
        }
    }
}