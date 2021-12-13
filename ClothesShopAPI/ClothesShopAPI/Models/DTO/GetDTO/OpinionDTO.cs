using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Models.DTO.GetDTO
{
    public class OpinionDTO
    {
        public int Id { get; set; }
        public uint OpinionSum { get; set; }
        public uint UserSum { get; set; }
        public float Average { get; set; }
        public OpinionDTO()
        {
            this.Average = this.AverageOpinion();
        }
        public float AverageOpinion()
        {
            if (this.UserSum == 0) return 0;
            return (float)this.OpinionSum / this.UserSum;
        }
    }
}
