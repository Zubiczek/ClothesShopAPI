using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothEntity
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public bool IsItInStock { get; set; }
        public string Description { get; set; }
        public uint Discount { get; set; }
        public int Category_Id { get; set; }
        public virtual ClothCategoryEntity Category { get; set; }
        public int Mark_Id { get; set; }
        public virtual ClothMarkEntity Mark { get; set; }
        public int Gender_Id { get; set; }
        public virtual GenderEntity Gender { get; set; }
        public int Opinion_Id { get; set; }
        public virtual ClothOpinionsEntity Opinions { get; set; }
        public virtual ICollection<UserBasketEntity> Baskets { get; set; }
        public virtual ICollection<OrderClothesEntity> Orders { get; set; }
        public virtual ICollection<ClothSizeEntity> ClothSizes { get; set; }
        public virtual ICollection<ClothCommentsEntity> Comments { get; set; }
        public ClothEntity()
        {
            Baskets = new List<UserBasketEntity>();
            Orders = new List<OrderClothesEntity>();
            ClothSizes = new List<ClothSizeEntity>();
            Comments = new List<ClothCommentsEntity>();
        }
    }
}
