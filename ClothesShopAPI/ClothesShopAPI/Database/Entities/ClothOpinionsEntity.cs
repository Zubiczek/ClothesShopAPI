using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class ClothOpinionsEntity
    {
        public int Id { get; set; }
        public uint OpinionSum { get; set; }
        public uint UserSum { get; set; }
        public int Cloth_Id { get; set; }
        public virtual ClothEntity Cloth { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
