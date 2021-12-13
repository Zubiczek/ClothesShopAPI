using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Database.Entities
{
    public class UserOpinionEntity
    {
        public int Opinion_Id { get; set; }
        public virtual ClothOpinionsEntity Opinion { get; set; }
        public string User_Id { get; set; }
        public virtual UserEntity User { get; set; }
        [Required]
        [Range(1, 5)]
        public uint Value { get; set; }
    }
}
