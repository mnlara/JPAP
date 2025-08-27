using AnitomySharp;

namespace JPAP.Services
{
    public interface IParserService
    {
        IEnumerable<Element> Parse(string filename);
    }
}
