using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class GenderEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ClothEntity> Clothes { get; set; }
        public GenderEntity()
        {
            Clothes = new List<ClothEntity>();
        }
    }
}
