using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringPalletsAndBoxes.Model
{
    public class Box
    {
        public int BoxId { get; private set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public int Volume 
        {
            get
            {
                return Width * Height * Depth;
            }
        }
        public DateOnly ShelfLife
        {
            get
            {
                if (field == default)
                    return field = MadeOn.AddDays(100);
                else
                    return field;
            }
            private set;
        }
        public DateOnly MadeOn { get; private set; }

        public Box(int boxId, int depth, int width, int height, int weight, DateOnly shelfLife)
        {
            if (boxId < 0) throw new ArgumentOutOfRangeException(nameof(boxId), "boxId must be greater than or equal to 0.");
            if (depth <= 0) throw new ArgumentOutOfRangeException(nameof(depth), "depth must be greater than 0.");
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "width must be greater than 0.");
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "height must be greater than 0.");
            if (weight <= 0) throw new ArgumentOutOfRangeException(nameof(weight), "weight must be greater than 0.");

            BoxId = boxId;
            Depth = depth;
            Width = width;
            Height = height;
            Weight = weight;
            ShelfLife = shelfLife;
        }
        public Box(int boxId, int depth, int width, int height, int weight, DateOnly madeOn, DateOnly shelfLife = default)
        {
            if (boxId < 0) throw new ArgumentOutOfRangeException(nameof(boxId), "boxId must be greater than or equal to 0.");
            if (depth <= 0) throw new ArgumentOutOfRangeException(nameof(depth), "depth must be greater than 0.");
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "width must be greater than 0.");
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "height must be greater than 0.");
            if (weight <= 0) throw new ArgumentOutOfRangeException(nameof(weight), "weight must be greater than 0.");

            BoxId = boxId;
            Depth = depth;
            Width = width;
            Height = height;
            Weight = weight;
            MadeOn = madeOn;
            ShelfLife = shelfLife;
        }

        public override string ToString()
        {
            return $"       Коробка ID: {BoxId}, Размеры: {Width}x{Height}x{Depth}, Вес: {Weight}, " +
                $"Объем: {Volume}, Срок годности: {ShelfLife.ToString("dd-MM-yyyy")}, Дата производства: {(MadeOn == default ? "Нету" : MadeOn.ToString("dd-MM-yyyy"))}";
        }
    }
}
