using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothSizeEntity
    {
        public int Cloth_Id { get; set; }
        public virtual ClothEntity Cloth { get; set; }
        public int Size_Id { get; set; }
        public virtual SizeEntity Size { get; set; }
        [Range(0, 1000)]
        public uint AvailableAmount { get; set; }
    }
}
