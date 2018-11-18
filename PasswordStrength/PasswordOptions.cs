
namespace PasswordStrength
{
    /// <summary>
    /// Model class for password validation options to validate
    /// </summary>
    public class PasswordOptions : IPasswordOptions
    {
        /// <summary>
        /// Check if password length 
        /// </summary>
        public bool Length { get; set; }

        /// <summary>
        /// Check if password contains lowercase letter
        /// </summary>
        public bool LowercaseLetter { get; set; }

        /// <summary>
        /// Check if password contains lowercase letter
        /// </summary>
        public bool UppercaseLetter { get; set; }

        /// <summary>
        /// Check if password contains Number
        /// </summary>
        public bool Number { get; set; }

        /// <summary>
        /// Check if password contains lowercase symbol
        /// </summary>
        public bool Symbol { get; set; }
    }
}
