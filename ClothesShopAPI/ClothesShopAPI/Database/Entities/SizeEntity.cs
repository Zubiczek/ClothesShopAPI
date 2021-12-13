using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class SizeEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3)]
        public string Size { get; set; }
        public virtual ICollection<UserBasketEntity> Baskets { get; set; }
        public virtual ICollection<ClothSizeEntity> ClothSizes { get; set; }
        public SizeEntity()
        {
            Baskets = new List<UserBasketEntity>();
            ClothSizes = new List<ClothSizeEntity>();
        }
    }
}
