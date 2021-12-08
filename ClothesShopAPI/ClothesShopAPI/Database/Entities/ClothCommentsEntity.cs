using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothCommentsEntity
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedOn { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
        public int Cloth_Id { get; set; }
        public virtual ClothEntity Cloth { get; set; }
        public ClothCommentsEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }
    }
}
