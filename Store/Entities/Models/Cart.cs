namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines=new();
        }
        public virtual void AddItem(Product product, int quantity)
        {
            CartLine? line=Lines.Where(list=> list.Product.ProductId==product.ProductId).FirstOrDefault();
            if(line is null)
            {
                Lines.Add(new()
                {
                    Product=product,
                    Quantity=quantity
                });
            }
            else
            {
                line.Quantity +=quantity;
            }
        }
        public virtual void RemoveLine(Product product)=> Lines.RemoveAll(list=>list.Product.ProductId.Equals(product.ProductId));
        public decimal ComputeTotalValue()=> Lines.Sum(p=>p.Product.Price* p.Quantity);
        public virtual void Clear()=>Lines.Clear();
    }
}