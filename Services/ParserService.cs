using AnitomySharp;

namespace JPAP.Services
{
    public class ParserService : IParserService
    {
        public IEnumerable<Element> Parse(string filename)
        {
            return Anitomy.Parse(filename);
        }
    }
}
