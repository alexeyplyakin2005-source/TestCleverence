using System.Text;

namespace Compression;

public static class StringCompressor
{
    public static string Compress(string strToCompress)
    {
        if (string.IsNullOrEmpty(strToCompress))
            return strToCompress;

        var result = new StringBuilder();
        int count = 1;

        for (int i = 1; i <= strToCompress.Length; i++)
        {
            if (i < strToCompress.Length && strToCompress[i] == strToCompress[i - 1])
            {
                count++;
            }
            else
            {
                result.Append(strToCompress[i - 1]);
                if (count > 1)
                    result.Append(count);

                count = 1;
            }
        }

        return result.ToString();
    }

    public static string Decompress(string strToDecompress)
    {
        if (string.IsNullOrEmpty(strToDecompress))
            return strToDecompress;

        var result = new StringBuilder();

        for (int i = 0; i < strToDecompress.Length; i++)
        {
            char symbol = strToDecompress[i];
            int count = 0;

            while (i + 1 < strToDecompress.Length && char.IsDigit(strToDecompress[i + 1]))
            {
                i++;
                count = count * 10 + (strToDecompress[i] - '0');
            }

            if (count == 0)
                count = 1;

            result.Append(new string(symbol, count));
        }

        return result.ToString();
    }
}
