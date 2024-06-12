namespace TrueProgrammer.Helpers
{
    /// <summary>
    /// Helper class for colored console processes such as prompts.
    /// </summary>
    internal static class ColoredConsole
    {
        /// <summary>
        /// Writes a line to the console with the selected color.
        /// </summary>
        /// <param name="displayedText">Text to display on console.</param>
        /// <param name="consoleColor">Console text color.</param>
        public static void WriteLine(string displayedText, ConsoleColor consoleColor)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(displayedText);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Writes to the console with the selected color.
        /// </summary>
        /// <param name="displayedText">Text to display on console.</param>
        /// <param name="consoleColor">Console text color.</param>
        public static void Write(string displayedText, ConsoleColor consoleColor)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            Console.Write(displayedText);
            Console.ForegroundColor = previousColor;
        }

        /// <summary>
        /// Prompts the user for input, switching the user's input to a cyan color so it stands out.
        /// </summary>
        /// <param name="promptText">Text to show to user asking for input.</param>
        /// <returns>string userInput</returns>
        public static string Prompt(string promptText)
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(promptText + " => ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string userInput = Console.ReadLine() ?? "";
            Console.ForegroundColor = previousColor;
            return userInput;
        }

        /// <summary>
        /// Prompts the user to press any key to continue.
        /// </summary>
        public static void Continue()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Uppercases the first letter of a string. Lowercases the rest.
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Uppercased inputString</returns>
        public static string UppercaseFirstLetter(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
                return string.Empty;
            return char.ToUpper(inputString[0]) + inputString.Substring(1).ToLower();
        }
    }
}
