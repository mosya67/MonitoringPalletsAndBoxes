using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringPalletsAndBoxes.Model
{
    public class Box
    {
        public int BoxId { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Volume 
        {
            get => Width * Height * Depth;
        }
        public DateOnly ShelfLife
        {
            get
            {
                if (field == default)
                    return (field = MadeOn).AddDays(100);
                else
                    return field;
            }
            set;
        }
        public DateOnly MadeOn { get; set; }

        public Box(int boxId, int depth, int width, int height, int weight, DateOnly shelfLife)
        {
            BoxId = boxId;
            Depth = depth;
            Width = width;
            Height = height;
            Weight = weight;
            ShelfLife = shelfLife;
        }
        public Box(int boxId, int depth, int width, int height, int weight, DateOnly madeOn, DateOnly shelfLife = default)
        {
            BoxId = boxId;
            Depth = depth;
            Width = width;
            Height = height;
            Weight = weight;
            MadeOn = madeOn;
            ShelfLife = shelfLife;
        }
    }
}
