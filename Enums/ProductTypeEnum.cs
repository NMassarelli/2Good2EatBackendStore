﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2Good2EatBackendStore.Enums
{
    public enum ProductTypeEnum
    {
        [Display(Name = "None")] None = 0
        , [Display(Name = "Candle")] Candle = 1
        , [Display(Name = "Wax Melt")] WaxMelt = 2
        , [Display(Name = "Crochet Item")] CrochetItem = 3
    }
}
