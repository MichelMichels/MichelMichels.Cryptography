namespace MichelMichels.CryptographyTests;

using MichelMichels.Cryptography;

[TestClass()]
public class BitOperatorTests
{
    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000)]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0010)]
    [DataRow((byte)0b1000_0001, (byte)0b0000_0011)]
    public void RotateLeft_Test(byte input, byte output)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        context.RotateLeft(inputArray);

        // Assert
        Assert.AreEqual(output, inputArray[0]);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000)]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0010)]
    [DataRow((byte)0b1000_0001, (byte)0b0000_0011)]
    public void RotateLeft_Single_Test(byte input, byte output)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        context.RotateLeft(inputArray, 1);

        // Assert
        Assert.AreEqual(output, inputArray[0]);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000, 7)]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0010, 7)]
    [DataRow((byte)0b0100_0001, (byte)0b0000_0011, 7)]
    [DataRow((byte)0b0010_0001, (byte)0b0000_0011, 6)]
    public void RotateLeft_Single_Length_Test(byte input, byte output, int length)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        context.RotateLeft(inputArray, 1, length);

        // Assert
        Assert.AreEqual(output, inputArray[0]);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000, 7, 1)]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0010, 7, 1)]
    [DataRow((byte)0b0100_0001, (byte)0b0000_0011, 7, 1)]
    [DataRow((byte)0b0010_0001, (byte)0b0000_0011, 6, 1)]
    [DataRow((byte)0b0010_0001, (byte)0b0000_0110, 6, 2)]
    public void RotateLeft_Single_Length_Rotations_Test(byte input, byte output, int length, int numberOfRotations)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        context.RotateLeft(inputArray, numberOfRotations, length);

        // Assert
        Assert.AreEqual(output, inputArray[0]);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000, (byte)0b0000_0000, (byte)0b0000_0000)]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0010, (byte)0b0000_0010, (byte)0b0000_0100)]
    [DataRow((byte)0b1000_0001, (byte)0b0000_0011, (byte)0b0000_0010, (byte)0b0000_0111)]
    public void RotateLeft_Multiple_Test(byte input1, byte input2, byte output1, byte output2)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input1, input2];
        context.RotateLeft(inputArray, 1);

        byte[] outputArray = [output1, output2];

        // Assert
        CollectionAssert.AreEqual(inputArray, outputArray);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000, (byte)0b0000_0000, (byte)0b0000_0000, 12)]
    [DataRow((byte)0b0100_0001, (byte)0b0000_0010, (byte)0b0000_0010, (byte)0b0000_0101, 15)]
    [DataRow((byte)0b0000_0011, (byte)0b0000_0011, (byte)0b0000_0010, (byte)0b0000_0111, 10)]
    public void RotateLeft_Multiple_Length_Test(byte input1, byte input2, byte output1, byte output2, int length)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input1, input2];
        context.RotateLeft(inputArray, 1, length);

        byte[] outputArray = [output1, output2];

        // Assert
        CollectionAssert.AreEqual(inputArray, outputArray);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000)]
    [DataRow((byte)0b0000_0001, (byte)0b1000_0000)]
    [DataRow((byte)0b1000_0001, (byte)0b1100_0000)]
    public void RotateRight_Test(byte input, byte output)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        context.RotateRight(inputArray);

        // Assert
        Assert.AreEqual(output, inputArray[0]);
    }

    [TestMethod()]
    [DataRow((byte)0b0000_0000, (byte)0b0000_0000)]
    [DataRow((byte)0b0000_0001, (byte)0b1000_0000)]
    [DataRow((byte)0b1000_0001, (byte)0b1100_0000)]
    public void RotateRight_Single_Test(byte input, byte output)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        context.RotateRight(inputArray, 1);

        // Assert
        Assert.AreEqual(output, inputArray[0]);
    }

    [TestMethod]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0010, false)]
    [DataRow((byte)0b0100_0000, (byte)0b1000_0000, false)]
    [DataRow((byte)0b1000_0000, (byte)0b0000_0000, true)]
    public void ShiftLeft_Test(byte input, byte expected, bool carryFlag)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        bool isCarried = context.ShiftLeft(inputArray);

        // Assert
        Assert.AreEqual(expected, inputArray[0]);
        Assert.AreEqual(carryFlag, isCarried);
    }

    [TestMethod]
    [DataRow((byte)0b0000_0001, (byte)0b0000_0000, true)]
    [DataRow((byte)0b0100_0000, (byte)0b0010_0000, false)]
    [DataRow((byte)0b0100_0001, (byte)0b0010_0000, true)]
    public void ShiftRight_Test(byte input, byte expected, bool carryFlag)
    {
        // Arrange
        BitOperator context = new();

        // Act
        byte[] inputArray = [input];
        bool isCarried = context.ShiftRight(inputArray);

        // Assert
        Assert.AreEqual(expected, inputArray[0]);
        Assert.AreEqual(carryFlag, isCarried);
    }
}