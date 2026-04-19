namespace Compression;

public class Program
{
    static void Main(string[] args)
    {
        string original = "aaabbcccdde";
        string compressed = StringCompressor.Compress(original);
        string decompressed = StringCompressor.Decompress(compressed);

        Console.WriteLine(original);     
        Console.WriteLine(compressed);   
        Console.WriteLine(decompressed);  
    }
}
