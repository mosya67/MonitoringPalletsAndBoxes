using MonitoringPalletsAndBoxes.Model;

namespace MonitoringPalletsAndBoxes
{
    internal class Program
    {
        public static List<Palet> palets = new List<Palet>();
        static void Main(string[] args)
        {
            generateData();

            var groups = palets.GroupBy(x => x.ShelfLife);
        }

        static void generateData()
        {
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                palets.Add(new Palet(i, 60, 60, 10));
                int boxCount = rnd.Next(1, 7);
                for (int j = 0; j < boxCount; j++)
                {
                    palets[i].AddBox(new(i, 10, 10, 15, rnd.Next(10, 40), madeOn: DateOnly.FromDateTime(DateTime.Now)));
                }
            }
        }
    }
}
