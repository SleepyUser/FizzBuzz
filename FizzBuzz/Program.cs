// See https://aka.ms/new-console-template for more information

using System.Data;

namespace FizzBuzz;

[Flags]
public enum Rules
{
    None    = 0b_0000_0000,
    Fizz    = 0b_0000_0001,
    Buzz    = 0b_0000_0010,
    Bang    = 0b_0000_0100,
    Bong    = 0b_0000_1000,
    Fezz    = 0b_0001_0000,
    Reverse = 0b_0010_0000,
    All = Fizz | Buzz | Bang | Bong | Fezz | Reverse
}

class FizzBuzz
{

    static void Main(string[] args)
    {
        var max = ChangeMaxNum();

        Console.WriteLine("Would you like to enable any rules?");
        InputChecks.getYN();
        Rules selectedRules = RuleChooser();
        for (int i = 1; i <= max; i++)
        {
            new FizzBuzzNum(i, selectedRules);
        }
    }

    private static int ChangeMaxNum()
    {
        int max = 100;
        Console.WriteLine("Please enter a number to FizzBuzz up to.");
        max = InputChecks.getValidInt();
        return max;
    }

    private static Rules RuleChooser()
    {
        Rules selectedRules = Rules.None;
        int input = 0;
        do
        {
            Console.WriteLine("Type a number to toggle that rule. (Or disable/enable all rules)");
            input = InputChecks.getValidInt(posOnly:true);
            if (input is (int)Rules.None or (int)Rules.All)
            {
                selectedRules = (Rules)input;
            }
            else if (input < (int)Rules.All)
            {
                selectedRules ^= (Rules)input;
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }
            Console.WriteLine("Finished? Y/N");
        } while (!InputChecks.getYN());

        return selectedRules;
    }

    private class FizzBuzzNum
    {
        private List<string> _output = new List<string>();
        private bool _numexists = true;
        private int _number = 0;
        private Rules _selectedRules;

        public FizzBuzzNum(int number, Rules selectedRules)
        {
            _number = number;
            _selectedRules = selectedRules;

            _output.Add(number.ToString());
            
            //fizz = (number % 3 == 0);
            if (checkRule(Rules.Fizz))
            {
                Fizz();
            }

            //buzz = (number % 5 == 0);
            if (checkRule(Rules.Buzz))
            {
                Buzz();
            }
            
            //bang = (number % 7 == 0);
            if (checkRule(Rules.Bang))
            {
                Bang();
            }
            
            //bong = (number % 11 == 0);
            if (checkRule(Rules.Bong))
            {
                Bong();
            }

            //fezz = (number % 13 == 0);
            if (checkRule(Rules.Fezz))
            {
                Fezz();
            }
            
            //reverse = (number % 17 == 0);
            if (checkRule(Rules.Reverse))
            {
                Reverse();
            }
            
            Console.WriteLine(string.Concat(_output));
        }

        private bool checkRule(Rules toCheck)
        {
            return (_selectedRules & toCheck) == toCheck;
        }

        private void Reverse()
        {
            if (_number % 17 == 0) //Reverse
            {
                _output.Reverse();
            }
        }

        private void Fezz()
        {
            if (_number % 13 == 0) //Fezz
            {
                if (_numexists) //if there is a number, replace it
                {
                    ReplaceNumber("Fezz");
                }
                else // if there is no number, insert before first "B" word. Else just append
                {
                    try
                    {
                        _output.Insert(_output.FindIndex(x => x[0] is 'B' or 'b'), "Fezz");
                    }
                    catch
                    {
                        _output.Append("Fezz");
                    }
                }
            }
        }

        private void Bong()
        {
            if (_number % 11 == 0) //Bong
            {
                _output.Clear();
                _output.Add("Bong");
            }
        }

        private void Bang()
        {
            if (_number % 7 == 0) //Bang
            {
                if (_output.Contains("Fizz") || _output.Contains("Buzz"))
                {
                    _output.Add("Bang");
                }
                else if (_numexists)
                {
                    ReplaceNumber("Bang");
                }
            }
        }

        private void Buzz()
        {
            if (_number % 5 == 0) //Buzz
            {
                if (_numexists)
                {
                    ReplaceNumber("Buzz");
                }
                else
                {
                    _output.Add("Buzz");
                }
            }
        }

        private void Fizz()
        {
            if (_number % 3 == 0) //Fizz
            {
                if (_numexists)
                {
                    ReplaceNumber("Fizz");
                }
                else
                {
                    _output.Add("Fizz");
                }
            }
        }

        private void ReplaceNumber(string replacement)
        {
            _output[_output.FindIndex(x => x == _number.ToString())] = replacement;
            _numexists = false;
        }
    }
}