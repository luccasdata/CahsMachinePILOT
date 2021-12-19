namespace MyApp // Note: actual namespace depends on the project name.
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("========== CASH MACHINE PILOT ==========");
            Console.WriteLine("========================================");
            Console.Write("Digite o valor que você deseja sacar: R$");
            double valor_de_saque = Validator(double.MinValue, double.MaxValue);
            
            double[] vect = new double[] {200, 100, 50, 20, 10, 5, 2, 1, 0.50, 0.25, 0.10, 0.05, 0.01 };

           foreach (var item in vect)
           {
               var cedulas = Math.Floor(valor_de_saque / item);
               if (cedulas > 0) 
               {
                   valor_de_saque = valor_de_saque % item;

                   var currency = item >= 1 ? "nota" : "moeda";

                   Console.WriteLine($"{cedulas} {currency}(s) de R${item.ToString("F2")}");
               }
           }
        }
        static double Validator(double min, double max)
        {
            double num;
            while (true)
            {
               #pragma warning disable CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
                string option = Console.ReadLine();
                #pragma warning restore CS8600 // Conversão de literal nula ou possível valor nulo em tipo não anulável.
                if (double.TryParse(option, out num))
                {
                    if (num >= min && num <= max)
                    {
                        return num;
                    }
                }
                Console.Write("Você não digitou um valor válido. ");
                Console.Write("Tente novamente: R$");
            }
        }
    }
}