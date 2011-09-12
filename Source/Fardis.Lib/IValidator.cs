using System;
namespace Fardis
{
    public interface IValidator
    {
        bool IsValidEmail(string source);
        bool IsValidWebAddress(string source);
    }
}
