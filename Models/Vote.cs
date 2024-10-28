using System.Security.Cryptography.X509Certificates;

namespace AurumServer.Models
{
    public class Vote
    {
        public int Id { get; set; }
        required public string Title { get; set; }
        required public string WriterName { get; set; }

        required public bool IsVoted { get; set; }

        required public List<VoteItem> Items { get; set; }

        public int TotalVotedCount => Items.Sum(item => item.VotedCount);
    }
}