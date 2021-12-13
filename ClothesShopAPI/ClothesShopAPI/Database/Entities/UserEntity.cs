using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class UserEntity : IdentityUser
    {
        public DateTime CreatedOn { get; set; }
        [MaxLength(50)]
        public string Address { get; set; }
        [MaxLength(30)]
        public string City { get; set; }
        [MaxLength(6)]
        public string ZipCode { get; set; }
        public virtual OrdersEntity Order { get; set; }
        public virtual ICollection<ClothCommentsEntity> Comments { get; set; }
        public virtual ICollection<UserBasketEntity> BasketClothes { get; set; }
        public virtual ICollection<UserOpinionEntity> Opinions { get; set; }
        public UserEntity()
        {
            CreatedOn = DateTime.UtcNow;
            Comments = new List<ClothCommentsEntity>();
            BasketClothes = new List<UserBasketEntity>();
            Opinions = new List<UserOpinionEntity>();
        }
    }
}
