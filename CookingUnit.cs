namespace RecipeConverterApp
{
    internal class CookingUnit
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public double MilliliterEquivalent { get; set; }

    

        // List of cooking units, each unit references a 'base' of milliliters for conversion operation. List will be used for input validation as well.
        public readonly static IReadOnlyList<CookingUnit> CookingList = new List<CookingUnit>()
            {
                new CookingUnit() { Name = "milliliter",  Abbreviation = "mL",     MilliliterEquivalent = 1         },
                new CookingUnit() { Name = "liter",       Abbreviation = "L",      MilliliterEquivalent = 1000      },
                new CookingUnit() { Name = "teaspoon",    Abbreviation = "tsp",    MilliliterEquivalent = 4.93      },
                new CookingUnit() { Name = "tablespoon",  Abbreviation = "Tbsp",   MilliliterEquivalent = 14.79     },
                new CookingUnit() { Name = "fluid ounce", Abbreviation = "fl.oz",  MilliliterEquivalent = 29.57     },
                new CookingUnit() { Name = "cup",         Abbreviation = "c",      MilliliterEquivalent = 236.59    },
                new CookingUnit() { Name = "pint",        Abbreviation = "pt",     MilliliterEquivalent = 473.18    },
                new CookingUnit() { Name = "quart",       Abbreviation = "qt",     MilliliterEquivalent = 946.35    }
            }.AsReadOnly();
    }
}
