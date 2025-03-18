namespace FinLit.Data.Interfaces
{
    public interface IAccount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string Currency { get; set; }
        public int UserId { get; set; }
    }
}
