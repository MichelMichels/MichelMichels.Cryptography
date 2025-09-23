namespace MichelMichels.Cryptography;

public interface IBitOperator
{
    void RotateLeft(byte[] data);
    void RotateLeft(byte[] data, int numberOfRotations);
    void RotateLeft(byte[] data, int numberOfRotations, int totalBitLength);

    void RotateRight(byte[] data);
    void RotateRight(byte[] data, int numberOfRotations);
    void RotateRight(byte[] data, int numberOfRotations, int totalBitLength);

    bool ShiftLeft(byte[] data);
    bool ShiftRight(byte[] data);
}
