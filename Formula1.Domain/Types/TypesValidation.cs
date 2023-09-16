using System;
using System.Text.RegularExpressions;

namespace Formula1.Domain.Types
{
    public static class TypesValidation
    {
        public static bool IsValidEmail(string? enderecoEmail)
        {
            if (string.IsNullOrEmpty(enderecoEmail))
                return false;

            return Regex.IsMatch(enderecoEmail, "\\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
        }
    }
}