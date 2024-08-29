using System.Text.RegularExpressions;

namespace vid2contactsheet.Helpers
{
    public static class TextBoxExtensions
    {
        public static bool ValidateResolution(this TextBox textBox)
        {
            string pattern = @"^\d{1,5}x\d{1,5}$"; // Matches 1 to 5 digits followed by 'x' and 1 to 5 digits
            return Regex.IsMatch(textBox.Text, pattern);
        }
    }
}
