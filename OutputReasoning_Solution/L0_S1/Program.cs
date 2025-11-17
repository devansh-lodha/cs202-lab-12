using System;

namespace L0_S1
{
    public delegate void AuthCallback(bool validUser);

    class Program
    {
        public static AuthCallback loginCallback = Login;

        public static void Login()
        {
            Console.WriteLine("Valid user!");
        }

        public static void Main(string[] args)
        {
            loginCallback(true);
        }
    }
}
