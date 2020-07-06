using System;

namespace ConsoleApplication_Calculation
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("+-----------------<[ Calculator Main Menu ]>-----------------+");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("|    1 - Do a calculation                                    |");
            Console.WriteLine("|    2 - List of previous calculations                       |");
            Console.WriteLine("|                                                            |");
            Console.WriteLine("+-----------------<[ Calculator Main Menu ]>-----------------+");
            var mainMenuOption = int.Parse(Console.ReadLine());
            switch (mainMenuOption)
            {
                case 1:
                    SubMenuOption();
                    break;
                case 2:
                    ListOption();
                    break;
                default:
                    Console.WriteLine("Nope");
                    break;
            }
        }
        
        public static void SubMenuOption()
        {
            Console.WriteLine("+-----------------<[ Calculator Sub Menu ]>-----------------+");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("|    1 - Add                                                |");
            Console.WriteLine("|    2 - Subtract                                           |");
            Console.WriteLine("|    3 - Multiply                                           |");
            Console.WriteLine("|    4 - Divide                                             |");
            Console.WriteLine("|                                                           |");
            Console.WriteLine("+-----------------<[ Calculator Sub Menu ]>-----------------+");
            var subMenuOption = int.Parse(Console.ReadLine());
            switch (subMenuOption)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    Subtract();
                    break;
                case 3:
                    Multiply();
                    break;
                case 4:
                    Divide();
                    break;
                default:
                    Console.WriteLine("Nope");
                    break;
            }
        }

        public static void ListOption()
        {
            CalculationRepository calculationRepository = new CalculationRepository();
            var listOfCalculations = calculationRepository.List();

            Console.WriteLine("--------------------------<[ Previous Calculations List ]>--------------------------");
            Console.WriteLine("");
            
            foreach (var calculation in listOfCalculations)
            {
                string symbol = "";
                switch (calculation.Operation)
                {
                    case OperationEnum.Add:
                        symbol = "+";
                        break;
                    case OperationEnum.Subtract:
                        symbol = "-";
                        break;
                    case OperationEnum.Multiply:
                        symbol = "*";
                        break;
                    case OperationEnum.Divide:
                        symbol = "/";
                        break;
                }
                Console.WriteLine("{0} {1} {2} = {3}", calculation.FirstNumber, symbol, calculation.SecondNumber, Calculate(calculation));
            }

            Console.WriteLine("");
            Console.WriteLine("--------------------------<[ Previous Calculations List ]>--------------------------");
        }
        
        static void Add()
        {
            var calculation = GetCalculation(OperationEnum.Add);
            var result = Calculate(calculation);
            StoreCalculation(calculation);
            Console.WriteLine("{0} + {1} = {2}", calculation.FirstNumber, calculation.SecondNumber, result);
        }
        
        static void Subtract()
        {
            var calculation = GetCalculation(OperationEnum.Subtract);
            var result = Calculate(calculation);
            StoreCalculation(calculation);
            Console.WriteLine("{0} - {1} = {2}", calculation.FirstNumber, calculation.SecondNumber, result);
        }
        
        static void Multiply()
        {
            var calculation = GetCalculation(OperationEnum.Multiply);
            var result = Calculate(calculation);
            StoreCalculation(calculation);
            Console.WriteLine("{0} * {1} = {2}", calculation.FirstNumber, calculation.SecondNumber, result);
        }
        
        static void Divide()
        {
            var calculation = GetCalculation(OperationEnum.Divide);
            var result = Calculate(calculation);
            StoreCalculation(calculation);
            Console.WriteLine("{0} / {1} = {2}", calculation.FirstNumber, calculation.SecondNumber, result);
        }

        static Calculation GetCalculation(OperationEnum operationEnum)
        {
            var calculation = new Calculation();
            calculation.Operation = operationEnum;
            return EnterCalculationNumbers(calculation);
        }
        
        static Calculation EnterCalculationNumbers(Calculation calculation)
        {
            Console.WriteLine("Enter the first number for the calculation:");
            calculation.FirstNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number for the calculation:");
            calculation.SecondNumber = double.Parse(Console.ReadLine());
            return calculation;
        }

        static void StoreCalculation(Calculation calculation)
        {
            CalculationRepository calculationRepository = new CalculationRepository();
            calculationRepository.Create(calculation);
        }

        static double Calculate(Calculation calculation)
        {
            var service = new CalculationService();
            return service.Calculate(calculation);
            
        }
    }
}