using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothOpinionsEntity
    {
        public int Id { get; set; }
        [Required]
        public uint OpinionSum { get; set; }
        [Required]
        public uint UserSum { get; set; }
        public int Cloth_Id { get; set; }
        public virtual ClothEntity Cloth { get; set; }
        public virtual ICollection<UserOpinionEntity> UserOpinioned { get; set; }
        public ClothOpinionsEntity()
        {
            UserOpinioned = new List<UserOpinionEntity>();
        }
    }
}
