using MonitoringPalletsAndBoxes.Model;
using System.Security.Principal;

namespace UnitTests;

[TestClass]
public class BoxTests
{

    [TestMethod]
    [DataRow(60, 60, 20, 72000)]
    [DataRow(20, 20, 20, 8000)]
    [DataRow(110, 110, 20, 242000)]
    public void VolumeTest(int depth, int width, int height, int expectedResult)
    {
        // Заглушка.
        var stub = 11;
        Box box = new(stub, depth, width, height, stub, default);

        Assert.AreEqual(expectedResult, box.Volume);
    }

    [TestMethod]
    [DataRow(-1, 3, 4, 4, 4)]
    [DataRow(1, -3, 4, 4, 4)]
    [DataRow(1, 3, 0, 4, 4)]
    [DataRow(1, 3, 4, -4, 4)]
    [DataRow(1, 3, 4, 4, 0)]
    public void CreateBoxTest_InvalidValues(int boxId, int depth, int width, int height, int weight)
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Box(boxId, depth, width, height, weight, default));
    }

    [TestMethod]
    [DataRow(2024, 11, 11, 2024, 11, 11)]
    [DataRow(2000, 3, 11, 2000, 3, 11)]
    public void ShelfLifeTest(int shelfLife_year, int shelfLife_month, int shelfLife_day, int expectedResult_year, int expectedResult_month, int expectedResult_day)
    {
        DateOnly shelfLife = new(shelfLife_year, shelfLife_month, shelfLife_day);
        DateOnly expectedResult = new(expectedResult_year, expectedResult_month, expectedResult_day);

        // Заглушка.
        var stub = 11; 
        Box box = new(stub, stub, stub, stub, stub, shelfLife);

        Assert.AreEqual(expectedResult, box.ShelfLife);
    }

    [TestMethod]
    [DataRow(2024, 11, 11)]
    [DataRow(2000, 3, 11)]
    public void ShelfLifeTest_MadeOn(int madeOn_year, int madeOn_month, int madeOn_day)
    {
        DateOnly madeOn = new(madeOn_year, madeOn_month, madeOn_day);
        DateOnly expectedResult = madeOn.AddDays(100);

        // Заглушка.
        var stub = 11;
        Box box = new(stub, stub, stub, stub, stub, madeOn: madeOn);

        Assert.AreEqual(expectedResult, box.ShelfLife);
    }
}
