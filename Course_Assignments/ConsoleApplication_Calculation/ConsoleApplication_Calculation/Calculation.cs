using System;

namespace ConsoleApplication_Calculation
{
    public class Calculation
    {
        public int Id { get; set; }
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }
        public OperationEnum Operation { get; set; }
    }
}