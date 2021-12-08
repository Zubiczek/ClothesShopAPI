using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class OrdersEntity
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsItPaid { get; set; }
        public bool IsItSend { get; set; }
        public bool IsItDelivered { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<OrderClothesEntity> Clothes { get; set; }
        public OrdersEntity()
        {
            Clothes = new List<OrderClothesEntity>();
        }
    }
}
