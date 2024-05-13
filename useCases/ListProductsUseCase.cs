using Products.dtos;

namespace Products.useCases
{
    public class ListProductsUseCase
    {
        private void title()
        {
            Console.WriteLine("Listagem dos produtos cadastrados:\n");
        }

        private void count(List<ProductDto> products)
        {
            Console.WriteLine($"Total de produtos cadastrados: {products.Count}");
        }

        private void show(List<ProductDto> products)
        {
            Console.WriteLine();
            foreach (var product in products)
            {
                string correctPriceFormat = product.price.ToString("F2");

                Console.WriteLine($"ID: {product.id}, Nome: {product.name}, Preço: {correctPriceFormat}");
            }
            Console.WriteLine();
        }

        private void closeProcess() 
        {
            Console.WriteLine("Pressione qualquer tecla para continuar");

            while (!Console.KeyAvailable) { }
         
            Console.ReadKey();
        }

        public void run(List<ProductDto> products)
        {
            this.title();
            
            this.count(products);

            this.show(products);

            this.closeProcess();
        }
    }
}
