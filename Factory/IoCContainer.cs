using Password;
using PasswordStrength;

namespace Factory
{
    public static class IoCContainer
    {
        public static IPasswordChecker PasswordChecker(IPasswordOptions options, string password) =>
            new PasswordChecker(options, password);

        public static IPasswordOptions PasswordOptions() =>
            new PasswordOptions();
    }
}
