
namespace MyFirstDll
{
    public class ContactValidator
    {
        public static Boolean ValidateName(String name)
        {
            return !string.IsNullOrEmpty(name) && name.All(Char.IsLetter);
        }

        public static Boolean ValidateAge(String age)
        {
            if (!String.IsNullOrEmpty(age) && age.All(Char.IsDigit))
            {
                Int32 ageValue = Int32.Parse(age);
                return ageValue >= 18;
            }
            return false;
        }
        public static Boolean ValidatePhone(String phone)
        {
            if (!String.IsNullOrEmpty(phone) && phone.Length == 13 && phone[0] == '+' &&
                 phone.Substring(1).All(Char.IsDigit))
            {
                return true;
            }
            return false;
        }
        public static Boolean ValidateEmail(String email)
        {
            return !String.IsNullOrEmpty(email) &&
                   email.Contains('@') &&
                   email.IndexOf('@') == email.LastIndexOf('@') &&
                   email.IndexOf('@') > 0 &&
                   email.IndexOf('@') < email.Length - 1;
        }
    }
}
