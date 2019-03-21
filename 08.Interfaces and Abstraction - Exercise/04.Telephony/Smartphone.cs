using System;

namespace _04.Telephony
{
    public class Smartphone : Validator, ICallable, IBrowseble
    {

        public string Browse(string url)
        {
            if (!ValidateWebSite(url))
            {
                throw new ArgumentException("Invalid URL!");
            }

            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            if (!ValidatePhoneNumber(number))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {number}";
        }
    }
}
