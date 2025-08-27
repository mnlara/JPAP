namespace JPAP.Models
{
    public class SeasonViewModel
    {
        public int SeasonId { get; set; }
        public string SeasonName { get; set; }

        public List<EpisodeViewModel> Episodes { get; set; }
    }
}
