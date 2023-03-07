using Task1_Calc.Models.Enums;

namespace Task1_Calc.Models.Common
{
    public static class NotationHelper
    {
        public static WordTypes GetWordType(string s)
        {
            switch (s)
            {
                case "(":
                    return WordTypes.Open;
                case ")":
                    return WordTypes.Close;

                case "√":
                    return WordTypes.Prefix;

                case "^":
                case "+":
                case "-":
                case "*":
                case "/":
                    return WordTypes.Postfix;

                default:
                    return WordTypes.Num;
            }
        }
    }
}
