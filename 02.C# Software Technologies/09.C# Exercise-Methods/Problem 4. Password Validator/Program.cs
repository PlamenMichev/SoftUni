using System;

namespace Problem_4._Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            bool CheckSizeBolean = CheckSize(password);
            if(CheckSizeBolean == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            bool checkCharsBolean = CheckChars(password);
            if(checkCharsBolean == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            bool checkDigitsBolean = CheckDigits(password);
            if(checkDigitsBolean == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if(checkCharsBolean == true
                && checkCharsBolean == true
                && checkDigitsBolean == true)
            {
                Console.WriteLine("Password is valid");
            }
        }
        public static bool CheckSize(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }
            return true;

        }
        public static bool CheckChars(string password)
        {
            bool check = true;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] > 57 || password[i] < 48)
                    &&(password[i] < 97 || password[i] > 122)
                    &&(password[i] < 65 || password[i] > 90))
                {
                    check = false;
                    break;
                }
            }
            if(check == false)
            {
                return false;
            }
            else return true;
        }
        public static bool CheckDigits(string password)
        {
            int count = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if(password[i] < 58 && password[i] > 47)
                {
                    count++;
                }
            }
            if (count < 2)
            {
                return false;
            }
            else return true;
        }
    }
}
