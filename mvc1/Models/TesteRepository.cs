namespace mvc1.Models
{
    public class TesteRepository : IRepository
    {
       private static Produto[] produtos = new Produto[]
       {
         new Produto{ ProdutoId = 10, Nome= "Caneta", Categoria="Escolar"},
         new Produto{ ProdutoId = 20, Nome= "Borracha", Categoria="Escolar"},
         new Produto{ ProdutoId = 30, Nome= "Estojo", Categoria="Escolar"}
       };
        public IEnumerable<Produto> GetProdutos { get => produtos; }
    }
}