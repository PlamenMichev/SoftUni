namespace _04.Telephony
{
    public class Validator
    {
        public bool ValidatePhoneNumber(string input)
        {
            foreach (var item in input)
            {
                if (!char.IsDigit(item))
                {
                    return false;
                }
            }

            return true;
        }

        public bool ValidateWebSite(string input)
        {
            foreach (var item in input)
            {
                if (char.IsDigit(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
