namespace FizzBuzz;

public static class InputChecks
{
    /// <summary>
    /// Asks the user to enter an operator, and repeats until they enter a valid input
    /// </summary>
    /// <returns>char: either +, -, /, *</returns>
    public static char getValidOperator()
    {
        Console.WriteLine("Please type an operator (*, /, +, -)");
        return GetValidChar(new[] { '+', '-', '/', '*' }, true);
    }

    /// <summary>
    /// Asks the user to enter a double, and repeatedly asks until a valid answer is entered
    /// </summary>
    /// <returns>the successfully entered double</returns>
    public static double getValidDouble()
    {
        while (true)
            try
            {
                return Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
            }
    }

    /// <summary>
    /// Asks the user to enter Y or N (not case sensitive) and returns the corresponding bool
    /// </summary>
    /// <returns>True if user entered Y, False if N</returns>
    public static bool getYN()
    {
        var input = "";
        while (true)
        {
            Console.WriteLine("Please enter Y or N.");
            input = Console.ReadLine() ?? string.Empty;
            if (input == "Y" || input == "y") return true;

            if (input == "N" || input == "n") return false;
            Console.WriteLine("Invalid input.");
        }
    }

    /// <summary>
    /// Asks the user to enter a character and checks it against the parameter list of valid characters
    /// Users will be asked to repeatedly enter a character until one on the list is entered.
    /// </summary>
    /// <param name="validChars">An array of chars considered valid by the check. If Case Sensitive is true,
    /// Array will be converted to upper case.</param>
    /// <param name="caseSensitive"> False by default, is the list of valid chars case sensitive?</param>
    /// <returns></returns>
    public static char GetValidChar(char[] validChars, bool caseSensitive = false)
    {
        var input = 'a'; // a used only to initalise
        if (!caseSensitive) //If not case sensitive, convert all to upper
            for (var i = 0; i < validChars.Length; i++)
                validChars[i] = char.ToUpper(validChars[i]);
        while (true)
        {
            input = GetValidChar();
            if (!caseSensitive) //If not case sensitive convert input to upper
                input = char.ToUpper(input);
            if (validChars.Contains(input)) return input;
            Console.WriteLine("Invalid Input, please enter only a valid character.");
        }
    }

    public static char GetValidChar()
    {
        var input = '0';
        while (!char.TryParse(Console.ReadLine() ?? string.Empty, out input))
            Console.WriteLine("Invalid input, please enter a valid character.");
        return input;
    }

    /// <summary>
    /// Asks the user to enter a date or time and returns the parsed datetime.
    /// Keeps asking if it cannot parse the input
    /// </summary>
    /// <returns>The parsed datetime</returns>
    public static DateTime getValidDateTime()
    {
        var input = DateTime.Now;
        while (!DateTime.TryParse(Console.ReadLine() ?? string.Empty, out input)) Console.WriteLine("Invalid input.");

        return input;
    }

    /// <summary>
    /// Asks the user to enter an int, and repeatedly asks until a valid answer is entered
    /// </summary>
    /// <returns>the successfully entered int</returns>
    public static int getValidInt(bool posOnly = false, bool nonZero = false)
    {
        var input = 0;
        while (true)
        {
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input, please try again.");
                continue;
            }

            if (nonZero && input == 0)
            {
                Console.WriteLine("Zero is not an acceptable input here.");
                continue;
            }

            if (posOnly && input < 0)
            {
                Console.WriteLine("Negative numbers are not accepted here.");
                continue;
            }

            return input;
        }
    }
}