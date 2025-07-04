using MonitoringPalletsAndBoxes.Model;

namespace MonitoringPalletsAndBoxes
{
    internal class Program
    {
        public static List<Palet> palets = new();
        static void Main(string[] args)
        {
            generateData();

            var groupedAndSortedPalets = Program.palets
                .GroupBy(palet => palet.ShelfLife)
                .OrderBy(group => group.Key)
                .Select(group => new
                {
                    ShelfLife = group.Key,
                    Palets = group.OrderBy(palet => palet.Weight)
                });

            var palletsWithMaxShelfLife = palets
                .OrderByDescending(palet => palet.Boxes.Select(box => box.ShelfLife).Max())
                .Take(3)
                .OrderBy(palet => palet.Volume);

            Console.WriteLine("3 паллеты, которые содержат коробки с наибольшим сроком годности:\n");

            foreach (Palet palet in palletsWithMaxShelfLife)
            {
                Console.WriteLine(palet);

                foreach (Box box in palet.Boxes.OrderBy(box => box.ShelfLife))
                {
                    Console.WriteLine(box);
                }

                Console.WriteLine();
            }

            Console.WriteLine(new string('=', 70));
            Console.WriteLine("\nВывод всех палетов:");

            foreach (var group in groupedAndSortedPalets)
            {
                Console.WriteLine($"Группа {group.ShelfLife.ToString()}:\n");

                foreach (Palet palet in group.Palets)
                {
                    Console.WriteLine(palet);

                    foreach (Box box in palet.Boxes.OrderBy(box => box.ShelfLife))
                    {
                        Console.WriteLine(box);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine(new string('-', 70));
            }

            Console.WriteLine();
        }

        static void generateData()
        {
            Random random = new();
            List<DateOnly> dates = new()
            {
                new(2024, 11, 21),
                new(2025, 11, 22),
                new(2023, 11, 22),
                new(2088, 11, 22),
                new(2023, 10, 22),
                new(2025, 9, 22),
                new(2024, 7, 22),
                new(2026, 5, 22),
            };

            for (int i = 0, boxId = 0; i < 8; i++)
            {
                Program.palets.Add(new Palet(paletId: i, depth: random.Next(60, 90), width: random.Next(60, 90), height: 10));
                int boxCount = random.Next(2, 4);
                for (var j = 0; j < boxCount; j++)
                {
                    Program.palets[i].AddBox(new Box(boxId: boxId++, depth: random.Next(5, 15), width: random.Next(5, 15), height: 15, weight: random.Next(10, 40), shelfLife: dates[random.Next(0, dates.Count)]));
                }
            }
        }
    }
}
