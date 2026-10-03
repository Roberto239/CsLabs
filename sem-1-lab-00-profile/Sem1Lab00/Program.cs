namespace Sem1Lab00;
class Programm
{
    public static void Main()
    {
        // Приветсвие и имя игрока
        Console.WriteLine("Welcome to the game!!!");
        Console.WriteLine("What is your name?");
        string username = Console.ReadLine();

        // Возраст
        Console.WriteLine("Enter your age:");
        string age = Console.ReadLine();
        int Age = Convert.ToInt32(age);

        // Пол
        Console.WriteLine("Enter your gender:");
        Console.WriteLine("Male or Female");
        string gender = Console.ReadLine();

        // Почта
        Console.Write("Enter your email: ");
        string email = Console.ReadLine();
        Console.WriteLine('\n');

        // Профиль игрока
        Console.WriteLine("This is your profile");
        Console.WriteLine("^_^ " + username + " ^_^");
        Console.WriteLine($"Age: {Age}");
        Console.WriteLine($"Gender: {gender}");
        Console.WriteLine($"Email: {email}");
    }
}