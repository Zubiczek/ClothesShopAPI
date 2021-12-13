using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class OrdersEntity
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [DefaultValue(false)]
        public bool IsItPaid { get; set; }
        [DefaultValue(false)]
        public bool IsItSend { get; set; }
        [DefaultValue(false)]
        public bool IsItDelivered { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<OrderClothesEntity> Clothes { get; set; }
        public OrdersEntity()
        {
            CreatedOn = DateTime.UtcNow;
            Clothes = new List<OrderClothesEntity>();
        }
    }
}
