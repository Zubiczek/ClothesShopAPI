using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothMarkEntity
    {
        public int Id { get; set; }
        [Required]
        public string MarkName { get; set; }
        public virtual ICollection<ClothEntity> Clothes { get; set; }
        public ClothMarkEntity()
        {
            Clothes = new List<ClothEntity>();
        }
    }
}
