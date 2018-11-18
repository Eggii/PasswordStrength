namespace Password
{
    public interface IPasswordChecker
    {
        int Length();
        bool ContainsLowercaseLetter { get; }
        bool ContainsUppercaseLetter { get; }
        bool ContainsNumber { get; }
        bool ContainsSymbol { get; }
        int GetPasswordStrength();
    }
}