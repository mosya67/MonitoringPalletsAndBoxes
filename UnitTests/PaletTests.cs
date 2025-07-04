using MonitoringPalletsAndBoxes.Model;

namespace UnitTests;

[TestClass]
public class PaletTests
{
    static Random random = new();
    [TestMethod]
    public void WeightTest()
    {
        // Заглушка.
        var stub = 60;
        var expectedResult = 30;
        Palet palet = new(stub, stub, stub, stub);

        // Сравнивается результат при Boxes.Count = 0.
        Assert.AreEqual(expectedResult, palet.Weight);

        for (var i = 0; i < 10; i++)
        {
            int BoxWeight = PaletTests.random.Next(12, 45);
            expectedResult += BoxWeight;
            palet.AddBox(new Box(stub, stub, stub, stub, BoxWeight, default));
        }

        Assert.AreEqual(expectedResult, palet.Weight);
    }

    [TestMethod]
    [DataRow(100, 110, 20)]
    [DataRow(200, 110, 20)]
    [DataRow(150, 120, 20)]
    [DataRow(130, 160, 20)]
    [DataRow(160, 80, 30)]
    public void VolumeTest(int paletDepth, int paletWidth, int paletHeight)
    {
        // Заглушка.
        var stub = 60;
        int expectedResult = paletDepth * paletWidth * paletHeight;
        Palet palet = new(stub, paletDepth, paletWidth, paletHeight);

        // Сравнивается результат при Boxes.Count = 0.
        Assert.AreEqual(expectedResult, palet.Volume);

        for (var i = 0; i < 10; i++)
        {
            int boxDepth = PaletTests.random.Next(1, paletDepth);
            int boxWidth = PaletTests.random.Next(1, paletWidth);
            var boxHeight = 10;
            expectedResult += boxDepth * boxWidth * boxHeight;
            palet.AddBox(new Box(stub, boxDepth, boxWidth, boxHeight, stub, default));
        }

        Assert.AreEqual(expectedResult, palet.Volume);
    }

    [TestMethod]
    public void ShelfLifeTest()
    {
        // Заглушка.
        var stub = 60;
        List<DateOnly> dates = new();
        Palet palet = new(stub, stub, stub, stub);

        // Сравнивается результат при Boxes.Count = 0.
        Assert.AreEqual(null, palet.ShelfLife);

        for (var i = 0; i < 10; i++)
        {
            int year = PaletTests.random.Next(1980, 2060);
            int month = PaletTests.random.Next(1, 13);
            int days = PaletTests.random.Next(1, 25);
            DateOnly date = new(year, month, days);
            dates.Add(date);
            palet.AddBox(new Box(stub, stub, stub, stub, stub, date));
        }
        Assert.AreEqual(dates.Min(), palet.ShelfLife);
    }

    [TestMethod]
    [DataRow(-1, 4, 5, 6)]
    [DataRow(2, -4, 5, 6)]
    [DataRow(2, 0, 5, 6)]
    [DataRow(2, 4, -5, 6)]
    [DataRow(2, 4, 0, 6)]
    [DataRow(2, 4, 5, -6)]
    [DataRow(2, 4, 5, 0)]
    public void CreatePaletTest_InvalidValues(int paletId, int depth, int width, int height)
    {
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Palet(paletId, depth, width, height));
    }

    [TestMethod]
    [DataRow(12, 39, true)]
    [DataRow(41, 25, true)]
    [DataRow(60, 40, true)]
    [DataRow(66, 33, false)]
    [DataRow(61, 32, false)]
    [DataRow(44, 330, false)]
    [DataRow(22, 320, false)]
    public void MethodAddBoxTest(int boxDepth, int boxWidth, bool expectedResult)
    {
        // Заглушка.
        var stub = 60;
        Palet palet = new(stub, 60, 40, stub);
        Box box = new (stub, boxDepth, boxWidth, stub, stub, default);
        bool isAdded = palet.AddBox(box);
        Assert.AreEqual(expectedResult, isAdded);

        if (expectedResult)
            // Сравниваем ссылки.
            Assert.AreEqual(palet.Boxes.Last(), box);
        else
            Assert.AreEqual(palet.Boxes.Count, 0);
    }
}
