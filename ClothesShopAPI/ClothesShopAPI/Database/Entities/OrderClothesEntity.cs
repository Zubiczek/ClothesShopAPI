using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class OrderClothesEntity
    {
        public string Order_Id { get; set; }
        public virtual OrdersEntity Order { get; set; }
        public int Cloth_Id { get; set; }
        public virtual ClothEntity Cloth { get; set; }
    }
}
