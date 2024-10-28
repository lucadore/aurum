using AurumServer.Models; 

namespace AurumServer.Services
{
    public class VoteService
    {
        private static readonly List<Vote> votes = [ 
        new Vote {
            Id = 1,
            Title = "title1",
            WriterName = "writer1",
            Items =
            [
                new VoteItem { Id = 1, Name = "title1 - item1", VotedCount = 4 },
                new VoteItem { Id = 2, Name = "title1 - item2", VotedCount = 10 },
                new VoteItem { Id = 3, Name = "title1 - item3", VotedCount = 20 }
            
            ],
            IsVoted = false
        },
         new Vote {
            Id = 2,
            Title = "title2",
            WriterName = "writer2",
            Items =
            [
                new VoteItem { Id = 1, Name = "title2 - item1", VotedCount = 20 },
                new VoteItem { Id = 2, Name = "title2 - item2", VotedCount = 4 },
                new VoteItem { Id = 3, Name = "title2 - item3", VotedCount = 3 }
            ],
            IsVoted = false
        },
        new Vote {
            Id = 3,
            Title = "title3",
            WriterName = "writer3",
            Items =
            [
                new VoteItem { Id = 1, Name = "title3 - item1", VotedCount = 9 },
                new VoteItem { Id = 2, Name = "title3 - item2", VotedCount = 7 },
                new VoteItem { Id = 3, Name = "title3 - item3", VotedCount = 3 }
            ],
            IsVoted = false
        }
        ];

        public Task<List<Vote>> GetAll()
        {
            // TODO: 데이터베이스 연동 필요
            return Task.FromResult(votes);
        }

        public Task<Vote> GetById(int id)
        {
            // TODO: 데이터베이스 연동 필요
            Vote? result = votes.Find(vote => vote.Id == id) ?? throw new Exception("Not Found");
            return Task.FromResult(result);
        }

        public Task<Vote> TakeVote(int id, int itemId)
        {
            // TODO: 데이터베이스 연동 필요
            // Vote와 VoteItem이 다른 테이블로 관리된다면 transaction 처리 필요
            Vote? vote = votes.Find(vote => vote.Id == id) ?? throw new Exception("Not Found"); // 400 Error
            VoteItem? item = vote.Items.Find(item => item.Id == itemId) ?? throw new Exception("Not Found Item");
            if (vote.IsVoted)
            {
                throw new Exception("Already Voted");
            }
            item.VotedCount++;
            vote.IsVoted = true;
            return Task.FromResult(vote);
        }
    }
}