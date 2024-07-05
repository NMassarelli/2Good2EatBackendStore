using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _2Good2EatStore.Data.Enums
{
	public enum ProductTypeEnum
	{
         [Display(Name = "None")] None = 0
		,[Display(Name = "Candle")] Candle = 1
		,[Display(Name = "Wax Melt")] WaxMelt = 2
        ,[Display(Name = "Crochet Plushie")] CrochetPlushie = 3
	}
}
