using ClothesShopAPI.Models.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClothesShopAPI.Services.ValidationService
{
    public interface IValidationService
    {
        int Validate(dynamic model);
    }
}
