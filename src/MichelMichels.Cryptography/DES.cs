namespace MichelMichels.Cryptography;

public class DES
{
    private readonly IBitOperator bitOperator = new BitOperator();

    private readonly int[] keyGenerationPermutationTable = [
        57, 49, 41, 33, 25, 17,  9,  1,
        58, 50, 42, 34, 26, 18, 10,  2,
        59, 51, 43, 35, 27, 19, 11,  3,
        60, 52, 44, 36, 63, 55, 47, 39,
        31, 23, 15,  7, 62, 54, 46, 38,
        30, 22, 14,  6, 61, 53, 45, 37,
        29, 21, 13,  5, 28, 20, 12,  4,
    ];

    private readonly int[] bitRotationTable = [
//      1  2  3  4  5  6  7  8  9 10 11 12 13 14 15 16
        1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1
    ];

    public List<byte[]> GenerateKeys(byte[] key)
    {
        if (key.Length != 8)
        {
            throw new ArgumentException("Key must be 64 bits.");
        }

        byte[] permutatedKey = bitOperator.Permutate(key, keyGenerationPermutationTable);
        if (permutatedKey.Length != 56 / 8)
        {
            throw new InvalidOperationException();
        }



        return [];
    }
}
