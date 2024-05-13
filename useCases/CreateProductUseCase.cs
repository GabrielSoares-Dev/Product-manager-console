using Products.domain;
using Products.dtos;

namespace Products.useCases
{
    public class CreateProductUseCase
    {
        private ProductDto getProductData()
        {
            Console.WriteLine("\nEntre com os dados do produto:");

            Console.Write("ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Preço: ");
            double price = Double.Parse(Console.ReadLine());

            return new ProductDto(id, name, price);
        }
        private void validProduct(ProductDto input)
        {
            Product entity = new Product(input);

            entity.create();
        }

        public List<ProductDto> run()
        {
            List<ProductDto> products = [];
            bool createProductFlowInProcessing = true;

            while(createProductFlowInProcessing)
            {
                try
                {
                    ProductDto productData = this.getProductData();
                    this.validProduct(productData);
                    products.Add(productData);

                    Console.Write("\nProduto cadastrado! Deseja cadastrar outro produto? (s/n): ");
                    bool rejectCreateOtherProduct = Console.ReadLine() == "n";
                    if (rejectCreateOtherProduct) createProductFlowInProcessing = false;
                }
                catch
                {
                    Console.Write("\nProduto não cadastrado! Deseja cadastrar outro produto? (s/n): ");

                    bool rejectRetryCreateProduct = Console.ReadLine() == "n";
                    if (rejectRetryCreateProduct) createProductFlowInProcessing = false;
                    
                }
            }

            return products;
        }
    }
}
