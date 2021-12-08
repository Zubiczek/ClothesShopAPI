using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class UserEntity : IdentityUser
    {
        public DateTime CreatedOn { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public virtual OrdersEntity Order { get; set; }
        public virtual ICollection<ClothOpinionsEntity> Opinions { get; set; }
        public virtual ICollection<ClothCommentsEntity> Comments { get; set; }
        public virtual ICollection<UserBasketEntity> BasketClothes { get; set; }
        public UserEntity()
        {
            CreatedOn = DateTime.UtcNow;
            Opinions = new List<ClothOpinionsEntity>();
            Comments = new List<ClothCommentsEntity>();
            BasketClothes = new List<UserBasketEntity>();
        }
    }
}
