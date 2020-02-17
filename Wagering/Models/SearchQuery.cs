namespace Wagering.Models
{
    public class SearchQuery
    {
        public string Username { get; set; }
        public string Game
        {
            get { return _game; }
            set { _game = value.ToLower(); }
        }
        private string _game;
        public int Page { get; set; }
        public int? PlayerCount { get; set; }
        public bool ShowClosed { get; set; }
        public decimal? MinimumWager { get; set; }
        public decimal? MaximumWager { get; set; }

        public SearchQuery()
        {
            Page = 1;
            ShowClosed = false;
        }
    }
}
