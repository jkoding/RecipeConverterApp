using static System.Console;

namespace RecipeConverterApp

{
    internal class ParseUserText
    {
        private static double amount;
        private static string unitFrom;
        private static string unitTo;  
        public static void ParseCommands(List<string> userCommands)
        {
            // This method breaks apart the user input and parses them into parameters for the Converter.ConvertUnit() method.
                   // Reset variables before parsing.
            unitFrom = null;
            unitTo = null;
            // Will be associated with the proper abbreviation of the unit user is converting to.
            string abbreviation = "";
            // The first input should always be a type double...reject command if not
            if (Double.TryParse(userCommands[0], out double value))
            {
                amount = Convert.ToDouble(userCommands[0]);                
            }
            else
            {
                Console.WriteLine("\nThe amount was not processed. Did you enter an appropiate amount? Please try again.");
            }
            // Assigns the 2nd and 3rd commands to the right measurement unit. If none are found, reprompt user to try again.
            for (int i = 2; i < userCommands.Count; i++)
            {
                foreach (CookingUnit unit in CookingUnit.CookingList)
                {
                    if (unit.Name.ToLower() == userCommands[1].ToLower() || unit.Abbreviation.ToLower() == userCommands[1].ToLower())
                    {
                        unitFrom = unit.Name;
                    }
                    else if (unit.Name.ToLower() == userCommands[2].ToLower() || unit.Abbreviation.ToLower() == userCommands[2].ToLower())
                    {
                        unitTo = unit.Name;
                        abbreviation = unit.Abbreviation;
                    }
                }    
            };
            // If the input was proper pass variables to the ConvertUnit() method, if no units are found prior reprompt user to try again.
            if (unitFrom != null && unitTo != null)
            {
                WriteLine($"{Converter.ConvertUnit(amount,unitFrom,unitTo)} {abbreviation}");
            }
            else
                Console.WriteLine("\nCommand was not formatted correctly...please try again.");
        }


            
    }
}
