using System.Linq;

namespace Calc
{
    public class Program2
    {
        public static int Main(string[] args)
        {
            return (args == null || args.Length == 0 || (args[0] != "sum" && args[0] != "product"))
                ? int.MinValue
                : args[0] == "sum"
                    ? args.Skip(1).Select(int.Parse).Aggregate(0, (a, b) => a + b)
                    : args.Skip(1).Select(int.Parse).Aggregate(1, (a, b) => a * b);
        }
    }
}
