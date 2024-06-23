namespace StockApp.API.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int ProductId{ get; set; }
        public int CustomerId { get; set; }
        public int  Nota { get; set; }
        public int Comment { get; set; }
    }
}
