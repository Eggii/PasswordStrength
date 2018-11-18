using PasswordStrength;
using System.Linq;

namespace Password
{
    /// <summary>
    /// Class for checking password strength
    /// </summary>
    public class PasswordChecker : IPasswordChecker
    {
        //Password strength by counted characters of password
        private const int WEAK = 6;
        private const int MEDIUM = 8;
        private const int STRONG = 10;

        private IPasswordOptions _passwordOptions; //Rules for checking password strength
        private string _password;

        /// <summary>
        /// Enum for mapping password strength 
        /// </summary>
        private enum Strength { Weak = 0, Medium = 1, Strong = 2 }

        /// <summary>
        /// Get password length
        /// </summary>
        private int PasswordLength => _password.Count();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <param name="password"></param>
        public PasswordChecker(IPasswordOptions options, string password)
        {
            _passwordOptions = options;
            _password = password;
        }

        /// <summary>
        /// Method for getting password strength by its length
        /// </summary>
        /// <returns>Returns password strength by its length</returns>
        public int Length()
        {
            if (this.PasswordLength <= WEAK)
                return (int)Strength.Weak;

            if (this.PasswordLength > WEAK && this.PasswordLength < STRONG)
                return (int)Strength.Medium;

            else
                return (int)Strength.Strong;
        }

        /// <summary>
        /// Check if password contains lowercase letters
        /// </summary>
        public bool ContainsLowercaseLetter => _password.Any(char.IsLower);

        /// <summary>
        /// Check if password contains uppercase letters
        /// </summary>
        public bool ContainsUppercaseLetter => _password.Any(char.IsUpper);

        /// <summary>
        /// Check if password contains numbers
        /// </summary>
        public bool ContainsNumber => _password.Any(char.IsNumber);

        /// <summary>
        /// Check if password contains symbol
        /// </summary>
        public bool ContainsSymbol => _password.Any(char.IsPunctuation) ||
            _password.Any(char.IsSymbol);

        /// <summary>
        /// Get strength of password
        /// </summary>
        /// <returns></returns>
        public int GetPasswordStrength()
        {
            int strength = 0;

            if (_passwordOptions.Length)
            {
                if (Length() == (int)Strength.Weak)
                    strength++;
                if (Length() == (int)Strength.Medium)
                    strength += 2;
                else
                    strength += 3;
            }

            if (_passwordOptions.LowercaseLetter &&
                this.ContainsLowercaseLetter)
                strength++;

            if (_passwordOptions.UppercaseLetter &&
                this.ContainsUppercaseLetter)
                strength++;

            if (_passwordOptions.Number &&
                this.ContainsNumber)
                strength++;

            if (_passwordOptions.Symbol &&
                this.ContainsSymbol)
                strength++;

            if (strength == 5)
                return (int)Strength.Weak;

            if (strength == 6)
                return (int)Strength.Medium;

            if (strength == 7)
                return (int)Strength.Strong;

            return (int)Strength.Weak;
        }
    }
}
