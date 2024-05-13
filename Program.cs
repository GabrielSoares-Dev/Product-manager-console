using Products.useCases;

namespace Products
{
   
    internal class Program
    {
        private static void welcome()
        {
            Console.WriteLine("Bem-vindo a segunda avaliacao A2!");
        }
        private static void authentication() 
        {
          LoginUseCase loginUseCase = new();
          loginUseCase.run();
        }

        private static void buildMenu()
        {
            BuildMenuUseCase buildMenuUseCase = new();
            buildMenuUseCase.run();
        }

        static void Main(string[] args)
        {
              welcome();
              authentication();
              buildMenu();
        }
    }
}
