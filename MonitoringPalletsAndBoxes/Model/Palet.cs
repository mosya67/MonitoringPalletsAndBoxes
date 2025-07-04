using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitoringPalletsAndBoxes.Model
{
    public class Palet
    {
        public int PaletId { get; set; }
        public int Depth { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Box> Boxes { get; private set; }
        public int Weight
        {
            get => field = Boxes.Sum(x => x.Weight) + 30;
            private set => field = value;
        }
        public int Volume
        {
            get => field = Boxes.Sum(x => x.Volume) + Width * Height * Depth;
            private set => field = value;
        }
        public DateOnly ShelfLife 
        { 
            get 
            {
                if (field == default)
                    return field = Boxes.Min(x => x.ShelfLife);
                else
                    return field;
            } 
            set => field = value;
        }

        public Palet(int paletId, int depth, int width, int height)
        {
            PaletId = paletId;
            Depth = depth;
            Width = width;
            Height = height;
        }

        /// <returns>Возвращает true, если удалось добавить, если нет - false</returns>
        public bool AddBox(Box box)
        {
            if (box.Width > this.Width || box.Depth > this.Depth)
                return false;

            Boxes.Add(box);
            return true;
        }
    }
}
