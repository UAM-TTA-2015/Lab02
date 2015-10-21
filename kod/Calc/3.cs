using System;
using System.Collections.Generic;
using System.Linq;

namespace Calc
{
    public interface ICalculator
    {
        int Calculate(Operation op, IEnumerable<int> arguments);
    }

    public class Calculator : ICalculator
    {
        public int Calculate(Operation op, IEnumerable<int> arguments)
        {
            switch (op)
            {
                case Operation.Sum:
                    return arguments.Aggregate(0, (a, b) => a + b);
                case Operation.Product:
                    return arguments.Aggregate(1, (a, b) => a * b);
                case Operation.Ndec:
                    return IsNonDecreasingSequence(arguments);
                case Operation.Aseq:
                    return IsArithmeticSequence(arguments);
                default:
                    throw new ArgumentOutOfRangeException(nameof(op), op, "unknown operation");
            }
        }
        private int IsNonDecreasingSequence(IEnumerable<int> arguments)
        {
            var listOfArguments = arguments.ToList();

            if (listOfArguments.Count == 0 || listOfArguments.Count == 1)
            {
                 return -1;
            }

            for (var i = 1; i < listOfArguments.Count; i++)
            {
                if (listOfArguments[i - 1] > listOfArguments[i])
                {
                    return 0;
                }
            }

            return 1;
        }

        private int IsArithmeticSequence(IEnumerable<int> arguments)
        {
            var listOfArguments = arguments.ToList();

            if (listOfArguments.Count == 0 || listOfArguments.Count == 1)
            {
                return -1;
            }

            var diff = listOfArguments[1] - listOfArguments[0];

            for (var i = 1; i < listOfArguments.Count; i++)
            {
               if ((listOfArguments[i] - listOfArguments[i - 1]) != diff)
               {
                    return 0;
               }
            }

            return 1;
        }
    }
    

    public enum Operation
    {
        Sum,
        Product,
        Ndec,
        Aseq
    }

    public class Prog
    {
        private readonly ICalculator _calculator;

        public Prog(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public int Run(string[] args)
        {
            Operation operation;
            if (args == null || args.Length == 0 || !Enum.TryParse(args.First(), true, out operation))
            {
                return int.MinValue;
            }

            var arguments = args.Skip(1).Select(int.Parse).ToList();

            try
            {
                return _calculator.Calculate(operation, arguments);
            }
            catch (ArgumentOutOfRangeException)
            {
                return int.MinValue;
            }
        }
    }

    public class Program
    {
        public static int Main(string[] args)
        {
            return new Prog(new Calculator()).Run(args);
        }
    }
}