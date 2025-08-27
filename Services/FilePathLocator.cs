using JPAP.Models;

namespace JPAP.Services
{
    public class FilePathLocator
    {
        //private readonly string _libraryPath = @"H:\Anime";
        private readonly string _libraryPath;
        private readonly IParserService _parser;

        public FilePathLocator(IParserService fileNameParser, IWebHostEnvironment env)
        {
            _parser = fileNameParser;

            var filePath = Path.Combine(env.ContentRootPath, "Data", "value.txt");

            if (File.Exists(filePath))
            {
                _libraryPath = File.ReadAllText(filePath).Trim();
            }
            else
            {
                _libraryPath = "";
            }
        }

        public List<SeriesViewModel> GetAllSeries()
        {
            var seriesList = new List<SeriesViewModel>();

            ScanFolder(_libraryPath, seriesList);

            return seriesList;
        }

        private void ScanFolder(string folderPath, List<SeriesViewModel> seriesList)
        {
            string[] subFolders;
            string[] files;

            try
            {
                subFolders = Directory.GetDirectories(folderPath);
                files = Directory.GetFiles(folderPath);
            }
            catch
            {
                return;
            }

            var episodes = new List<EpisodeViewModel>();
            int fallbackCounter = 1;
            var usedNumbers = new HashSet<int>();

            foreach (var file in files)
            {
                try
                {
                    var elements = _parser.Parse(Path.GetFileName(file));

                    var episodeTitle = elements.FirstOrDefault(e => e.Category.ToString() == "ElementEpisodeTitle")?.Value;
                    var episodeNumber = elements.FirstOrDefault(e => e.Category.ToString() == "ElementEpisodeNumber")?.Value;

                    int epNum;
                    if (int.TryParse(episodeNumber, out epNum) && epNum > 0)
                    {
                        usedNumbers.Add(epNum);
                    }
                    else
                    {
                        while (usedNumbers.Contains(fallbackCounter))
                        {
                            fallbackCounter++;
                        }
                        epNum = fallbackCounter;
                        usedNumbers.Add(epNum);
                    }

                    episodes.Add(new EpisodeViewModel
                    {
                        EpisodeNumber = epNum ,
                        Title = episodeTitle ?? epNum.ToString(),
                        FilePath = file
                    });
                }
                catch
                {

                }
            }

            if (episodes.Any())
            {
                var seriesName = Path.GetFileName(Path.GetDirectoryName(folderPath)) ?? Path.GetFileName(folderPath);

                var series = seriesList.FirstOrDefault(s => s.SeriesName == seriesName);
                if (series == null)
                {
                    series = new SeriesViewModel
                    {
                        SeriesName = seriesName,
                        Seasons = new List<SeasonViewModel>()
                    };
                    seriesList.Add(series);
                }

                series.Seasons.Add(new SeasonViewModel
                {
                    SeasonName = Path.GetFileName(folderPath),
                    Episodes = episodes.OrderBy(e => e.EpisodeNumber).ToList()
                });
            }

            foreach (var subFolder in subFolders)
            {
                try
                {
                    var attributes = File.GetAttributes(subFolder);
                    if (attributes.HasFlag(FileAttributes.Directory) && !attributes.HasFlag(FileAttributes.ReparsePoint))
                    {
                        ScanFolder(subFolder, seriesList);
                    }
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
