namespace AurumServer.Models
{
    public class VoteItem
    {
        public int Id { get; set; }
        required public string Name { get; set; }
        required public int VotedCount { get; set; }
    }
}