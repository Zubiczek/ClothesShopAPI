using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class UserBasketEntity
    {
        public int Cloth_Id { get; set; }
        public virtual ClothEntity Cloth { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
        public int Size_Id { get; set; }
        public virtual SizeEntity Size { get; set; }
        public DateTime AddOn { get; set; }
        public UserBasketEntity()
        {
            AddOn = DateTime.UtcNow;
        }
    }
}
