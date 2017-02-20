namespace BusinessLogic.Helpers
{
    public interface IURLShortener
    {
        string Encode(long number);
        long Decode(string shortPath);
    }
}