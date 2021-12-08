using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothCategoryEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<ClothEntity> Clothes { get; set; }
        public ClothCategoryEntity()
        {
            Clothes = new List<ClothEntity>();
        }
    }
}
