namespace MatchMaking.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Sex { get; set; } = string.Empty;
        public int Age { get; set; }
        public string PicturePath { get; set; } = string.Empty;
        public int Score { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
