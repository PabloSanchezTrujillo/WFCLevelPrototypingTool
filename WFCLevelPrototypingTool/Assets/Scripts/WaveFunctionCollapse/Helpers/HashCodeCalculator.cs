using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

public static class HashCodeCalculator
{
    public static string CalculateHashCode(int[][] grid)
    {
        byte[] tmpSource = grid.SelectMany(x => GetByteArrayFromIntArray(x)).ToArray();
        byte[] tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

        return ByteArrayToString(tmpHash);
    }

    public static byte[] GetByteArrayFromIntArray(int[] intArray)
    {
        byte[] data = new byte[intArray.Length * 4];

        for(int i = 0; i < intArray.Length; i++) {
            Array.Copy(BitConverter.GetBytes(intArray[i]), 0, data, i * 4, 4);
        }

        return data;
    }

    private static string ByteArrayToString(byte[] arrayInput)
    {
        int i;
        StringBuilder stringOutput = new StringBuilder(arrayInput.Length);

        for(i = 0; i < arrayInput.Length; i++) {
            stringOutput.Append(arrayInput[i].ToString("X2"));
        }

        return stringOutput.ToString();
    }
}