namespace JPAP.Models
{
    public class SeriesViewModel
    {
        public int SeriesId { get; set; }
        public string SeriesName { get; set; }

        public List<SeasonViewModel> Seasons { get; set; }
    }
}

