
using Products.dtos;

namespace Products.useCases
{
    public class BuildMenuUseCase
    {
        private void closeProgram()
        {
            Console.WriteLine("\nPrograma finalizado!\n");
            Environment.Exit(0);
        }

        private void buildOptionSelected(int optionSelected, List<ProductDto> products)
        {
            switch (optionSelected)
            {
                case 1:
                    CreateProductUseCase createProductUseCase = new();
                    List<ProductDto> productsCreated = createProductUseCase.run();
                    products.AddRange(productsCreated);
                    break;
                case 2:
                    ListProductsUseCase listProductsUseCase = new();
                    listProductsUseCase.run(products);
                    break;
                case 3:
                    this.closeProgram();
                    break;
                default:
                    Console.WriteLine("\nOpcao inválida!\n");
                    break;
            }
        }

        public void run()
        {
            List<ProductDto> products = [];

            string userName = "hamilton";
            while (true)
            {
                int optionSelected = 1;
                Console.WriteLine($"Bem-vindo {userName}");
                Console.WriteLine("Opções:\n");
                Console.WriteLine("1 – Cadastrar produto(s)");
                Console.WriteLine("2 – Visualizar produto(s)");
                Console.WriteLine("3 – Finalizar programa\n");
                Console.Write("O que deseja fazer? ");

                try
                {
                    optionSelected = int.Parse(Console.ReadLine());
                    this.buildOptionSelected(optionSelected, products);
                }
                catch {
                    Console.WriteLine("Opcao inválida!");
                }
            }
           
        }
    }
}
