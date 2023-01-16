namespace mvc1.Models
{
    public interface IRepository
    {
        IEnumerable<Produto> GetProdutos {get;}
    }
}