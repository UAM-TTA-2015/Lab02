namespace Calc
{
    // taki kod też działa
    public class Program1
    {
        public static int Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return int.MinValue;
            }

            if (args[0] == "sum")
            {
                int sum = 0;

                for (int i = 1; i < args.Length; i++)
                {
                    sum += int.Parse(args[i]);
                }

                return sum;
            }

            if (args[0] == "product")
            {
                int product = 1;

                for (int i = 1; i < args.Length; i++)
                {
                    product *= int.Parse(args[i]);
                }

                return product;
            }

            return int.MinValue;
        }
    }
}
