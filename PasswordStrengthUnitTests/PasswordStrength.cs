using Factory;
using PasswordStrength;
using Xunit;

namespace PasswordStrengthUnitTests
{
    /// <summary>
    /// Test class for testing password strengths
    /// </summary>
    public class PasswordStrength
    {
        private const int STRONG = 2;
        private const int MEDIUM = 1;
        private const int WEAK = 0;
        private string password = "Password1.";
       
        [Fact]
        public void PasswordChecker_LengthIsStrong_ExpectSTRONG()
        {
            var checker = IoCContainer.PasswordChecker(
                new PasswordOptions(), password);

            Assert.Equal(STRONG, checker.Length());
        }

        [Fact]
        public void PasswordChecker_ContainsLowercaseLetter_ReturnsTrue()
        {
            var checker = IoCContainer.PasswordChecker(
                new PasswordOptions(), password);

            Assert.True(checker.ContainsLowercaseLetter);
        }

        [Fact]
        public void PasswordChecker_ContainsUppercaseLetter_ReturnsTrue()
        {
            var checker = IoCContainer.PasswordChecker(
                new PasswordOptions(), password);

            Assert.True(checker.ContainsUppercaseLetter);
        }

        [Fact]
        public void PasswordChecker_ContainsNumber_ReturnsTrue()
        {
            var checker = IoCContainer.PasswordChecker(
                new PasswordOptions(), password);

            Assert.True(checker.ContainsNumber);
        }

        [Fact]
        public void PasswordChecker_ContainsSymbol_ReturnsTrue()
        {
            var checker = IoCContainer.PasswordChecker(
                new PasswordOptions(), password);

            Assert.True(checker.ContainsSymbol);
        }

        [Fact]
        public void PasswordChecker_IfPasswordIsStrong_ExpectSTRONG()
        {
            var cheker = IoCContainer.PasswordChecker(new PasswordOptions()
            {
                Length = true,
                LowercaseLetter = true,
                UppercaseLetter = true,
                Number = true,
                Symbol = true
            }, password);

            Assert.Equal(STRONG, cheker.GetPasswordStrength());
        }

        [Fact]
        public void PasswordChecker_IfPasswordIsMedium_ExpectMEDIUM()
        {
            password = "Password11";
            var cheker = IoCContainer.PasswordChecker(new PasswordOptions()
            {
                Length = true,
                LowercaseLetter = true,
                UppercaseLetter = true,
                Number = true,
                Symbol = true
            }, password);

            Assert.Equal(MEDIUM, cheker.GetPasswordStrength());
        }

        [Fact]
        public void PasswordChecker_IfPasswordIsWeak_ExpectWEAK()
        {
            password = "Password";
            var cheker = IoCContainer.PasswordChecker(new PasswordOptions()
            {
                Length = true,
                LowercaseLetter = true,
                UppercaseLetter = true,
                Number = true,
                Symbol = true
            }, password);

            Assert.Equal(WEAK, cheker.GetPasswordStrength());
        }
    }
}
