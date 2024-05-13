namespace Products.dtos
{
    public class ProductDto(int id, string name, double price)
    {
        public int id { get; private set; } = id;
        public string name { get; private set; } = name;
        public double price { get; private set; } = price;
    }
}
