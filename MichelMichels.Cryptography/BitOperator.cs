namespace MichelMichels.Cryptography;

public class BitOperator : IBitOperator
{
    private const int NumberOfBitsInByte = 8;

    public void RotateLeft(byte[] bytes, int numberOfRotations)
    {
        ArgumentNullException.ThrowIfNull(bytes);

        if (numberOfRotations < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfRotations), "The number of rotations must be non-negative.");
        }

        numberOfRotations %= (bytes.Length * NumberOfBitsInByte);
        for (int i = 0; i < numberOfRotations; i++)
        {
            RotateLeft(bytes);
        }
    }

    public void RotateLeft(byte[] bytes, int numberOfRotations, int bitLength)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        if (numberOfRotations < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfRotations), "The number of rotations must be non-negative.");
        }
        if (bitLength < 0 || bitLength > bytes.Length * NumberOfBitsInByte)
        {
            throw new ArgumentOutOfRangeException(nameof(bitLength), "The bit length must be non-negative and less than or equal to the total number of bits in the byte array.");
        }

        numberOfRotations %= bitLength;
        for (int i = 0; i < numberOfRotations; i++)
        {
            RotateLeftWithLength(bytes, bitLength);
        }
    }

    /// <summary>
    /// Rotates the bits in an array of bytes to the left.
    /// </summary>
    /// <param name="bytes">The byte array to rotate.</param>
    public void RotateLeft(byte[] bytes)
    {
        bool carryFlag = ShiftLeft(bytes);

        if (carryFlag)
        {
            bytes[^1] = (byte)(bytes[^1] | 0b0000_0001);
        }
    }

    /// <summary>
    /// Rotates the bits in an array of bytes to the left.
    /// </summary>
    /// <param name="bytes">The byte array to rotate.</param>
    public void RotateLeftWithLength(byte[] bytes, int length)
    {
        RotateLeft(bytes);

        byte mod = (byte)(length % NumberOfBitsInByte);
        if (mod == 0)
        {
            return;
        }

        byte shifted = (byte)(bytes[0] >> mod);
        bytes[0] = (byte)(bytes[0] & mod);
        bytes[^1] = (byte)(bytes[^1] | shifted);
    }

    public void RotateRight(byte[] bytes, int numberOfRotations)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        if (numberOfRotations < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfRotations), "The number of rotations must be non-negative.");
        }
        numberOfRotations %= (bytes.Length * NumberOfBitsInByte);
        for (int i = 0; i < numberOfRotations; i++)
        {
            RotateRight(bytes);
        }
    }

    public void RotateRight(byte[] bytes, int numberOfRotations, int bitLength)
    {
        ArgumentNullException.ThrowIfNull(bytes);
        if (numberOfRotations < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfRotations), "The number of rotations must be non-negative.");
        }
        if (bitLength < 0 || bitLength > bytes.Length * NumberOfBitsInByte)
        {
            throw new ArgumentOutOfRangeException(nameof(bitLength), "The bit length must be non-negative and less than or equal to the total number of bits in the byte array.");
        }
        numberOfRotations %= bitLength;
        for (int i = 0; i < numberOfRotations; i++)
        {
            RotateRightWithLength(bytes, bitLength);
        }
    }

    public void RotateRightWithLength(byte[] bytes, int length)
    {
        RotateRight(bytes);
        byte mod = (byte)(length % NumberOfBitsInByte);
        if (mod == 0)
        {
            return;
        }

        byte shifted = (byte)(bytes[^1] << mod);
        bytes[^1] = (byte)(bytes[^1] & (0xFF << mod));
        bytes[0] = (byte)(bytes[0] | shifted);
    }
    /// <summary>
    /// Rotates the bits in an array of bytes to the right.
    /// </summary>
    /// <param name="bytes">The byte array to rotate.</param>
    public void RotateRight(byte[] bytes)
    {
        bool carryFlag = ShiftRight(bytes);

        if (carryFlag == true)
        {
            bytes[0] = (byte)(bytes[0] | 0b1000_0000);
        }
    }

    /// <summary>
    /// Shifts the bits in an array of bytes to the left.
    /// </summary>
    /// <param name="bytes">The byte array to shift.</param>
    public bool ShiftLeft(byte[] bytes)
    {
        bool leftMostCarryFlag = false;

        // Iterate through the elements of the array from left to right.
        for (int index = 0; index < bytes.Length; index++)
        {
            // If the leftmost bit of the current byte is 1 then we have a carry.
            bool carryFlag = (bytes[index] & 0b1000_0000) > 0;

            if (index > 0)
            {
                if (carryFlag)
                {
                    // Apply the carry to the rightmost bit of the current bytes neighbor to the left.
                    bytes[index - 1] = (byte)(bytes[index - 1] | 0x01);
                }
            }
            else
            {
                leftMostCarryFlag = carryFlag;
            }

            bytes[index] = (byte)(bytes[index] << 1);
        }

        return leftMostCarryFlag;
    }

    /// <summary>
    /// Shifts the bits in an array of bytes to the right.
    /// </summary>
    /// <param name="bytes">The byte array to shift.</param>
    public bool ShiftRight(byte[] bytes)
    {
        bool rightMostCarryFlag = false;
        int rightEnd = bytes.Length - 1;

        // Iterate through the elements of the array right to left.
        for (int index = rightEnd; index >= 0; index--)
        {
            // If the rightmost bit of the current byte is 1 then we have a carry.
            bool carryFlag = (bytes[index] & 0x01) > 0;

            if (index < rightEnd)
            {
                if (carryFlag == true)
                {
                    // Apply the carry to the leftmost bit of the current bytes neighbor to the right.
                    bytes[index + 1] = (byte)(bytes[index + 1] | 0x80);
                }
            }
            else
            {
                rightMostCarryFlag = carryFlag;
            }

            bytes[index] = (byte)(bytes[index] >> 1);
        }

        return rightMostCarryFlag;
    }
}
