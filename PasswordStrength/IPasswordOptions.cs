namespace PasswordStrength
{
    public interface IPasswordOptions
    {
        bool Length { get; set; }
        bool LowercaseLetter { get; set; }
        bool Number { get; set; }
        bool Symbol { get; set; }
        bool UppercaseLetter { get; set; }
    }
}