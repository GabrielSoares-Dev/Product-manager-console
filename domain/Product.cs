using Products.dtos;

namespace Products.domain
{
    public class Product(ProductDto input)
    {
        public ProductDto input = input;

        private bool invalidId()
        {
            bool isEmpty = this.input.id == 0;
            bool isNegative = int.IsNegative(this.input.id);

            return isEmpty || isNegative;
        }

        private bool invalidName()
        {
            return String.IsNullOrEmpty(this.input.name);
        }

        private bool invalidPrice()
        {
            bool isNaN = Double.IsNaN(this.input.price);
            bool isAnormal = !Double.IsNormal(this.input.price);
            bool isNegative = Double.IsNegative(this.input.price);

            return isNaN || isAnormal || isNegative;
        }

        public void create()
        {
            bool invalidId = this.invalidId();
            bool invalidName = this.invalidName();
            bool invalidPrice = this.invalidPrice();
            bool invalidParameters = invalidId || invalidName || invalidPrice;

            if (invalidParameters) throw new Exception("Invalid parameters");
        }

    }
}
