using System;
using System.Reflection;
// using System.Security.Cryptography;
// System.Collections.Generic;

class Program
{

    // Data is private
    // Private says, "u cannot look at this from outside ):<"
    static void Main(string[] args)
    {
        Console.WriteLine("Bonjour Tout Le Monde");

        Employee employee = new Employee("Bob", 40, 23.77);

        // Console.WriteLine($"{employee.GetName()} is due: {employee.GetPay()}");
        // Console.WriteLine("Pay him now )=<");

        ConstructionWorker constructionWorker = new ConstructionWorker("Betty", 40, 35.8);
        // Console.WriteLine($"{constructionWorker.GetName()} is due: {constructionWorker.GetPay()}");

        Doctor doctor = new Doctor("Belinda", 240000.99);
        // Console.WriteLine($"{doctor.GetName()} is due: {employee.GetPay()}");


        List<Employee> employees = new List<Employee>();
        employees.Add(employee);
        employees.Add(constructionWorker);
        employees.Add(doctor);

        foreach (Employee e in employees)
        {
            Console.WriteLine($"{e.GetName()} is due: {e.GetPay()}");
            Console.WriteLine("Pay him now )=<");
        }
    }
}
