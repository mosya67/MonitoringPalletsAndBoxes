using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringPalletsAndBoxes.Model
{
    public class Palet
    {
        public int PaletId { get; private set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public List<Box> Boxes { get; private set; }
        public int Weight
        {
            get
            {
                if (Boxes.Count == 0)
                    return 30;

                return field = Boxes.Sum(box => box.Weight) + 30;
            }
            private set => field = value;
        }
        public int Volume
        {
            get
            {
                if (Boxes.Count == 0)
                    return Width * Height * Depth;

                return field = Boxes.Sum(box => box.Volume) + Width * Height * Depth;
            }
            private set => field = value;
        }
        public DateOnly? ShelfLife 
        { 
            get 
            {
                if (Boxes.Count == 0)
                    return null;

                if (field == null)
                    return field = Boxes.Min(box => box.ShelfLife);
                else
                    return field;
            }
            private set => field = value;
        }

        public Palet(int paletId, int depth, int width, int height)
        {
            if (paletId < 0) throw new ArgumentOutOfRangeException(nameof(paletId), "paletId must be greater than or equal to 0.");
            if (depth <= 0) throw new ArgumentOutOfRangeException(nameof(depth), "depth must be greater than 0.");
            if (width <= 0) throw new ArgumentOutOfRangeException(nameof(width), "width must be greater than 0.");
            if (height <= 0) throw new ArgumentOutOfRangeException(nameof(height), "height must be greater than 0.");
            PaletId = paletId;
            Depth = depth;
            Width = width;
            Height = height;
            Boxes = new List<Box>();
        }

        /// <returns>Возвращает true, если удалось добавить, если нет - false.</returns>
        public bool AddBox(Box box)
        {
            if ((box.Width > this.Width) || (box.Depth > this.Depth))
                return false;

            Boxes.Add(box);
            return true;
        }

        public override string ToString()
        {
            return $"Палет ID: {PaletId}, Размеры: {Width}x{Height}x{Depth}, Вес: {Weight}, Объем: {Volume}, Срок годности: {ShelfLife?.ToString("dd-MM-yyyy") ?? "Нет"}";
        }
    }
}
