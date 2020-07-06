using System;
using System.Net.Sockets;

namespace ConsoleApplication_Calculation
{
    public class CalculationService
    {
        private double Add(Calculation calculation)
        {
            return calculation.FirstNumber + calculation.SecondNumber;
        }

        private double Subtract(Calculation calculation)
        {
            return calculation.FirstNumber - calculation.SecondNumber;
        }

        private double Multiply(Calculation calculation)
        {
            return calculation.FirstNumber * calculation.SecondNumber;
        }

        private double Divide(Calculation calculation)
        {
            return calculation.FirstNumber / calculation.SecondNumber;
        }

        public double Calculate(Calculation calculation)
        {
            switch (calculation.Operation)
            {
                case OperationEnum.Add:
                    return Add(calculation);
                case OperationEnum.Subtract:
                    return Subtract(calculation);
                case OperationEnum.Multiply:
                    return Multiply(calculation);
                case OperationEnum.Divide:
                    return Divide(calculation);
                default:
                    return 0;
            }
        }
    }
}