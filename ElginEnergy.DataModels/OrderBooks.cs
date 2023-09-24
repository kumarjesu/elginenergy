using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElginEnergy.DataModels
{
    [Table("OrderBooks")]
    public class OrderBooks
    {
        [Required]
        [DataType(DataType.Date)]
        [Column("TradingDay")] public DateTime TradingDay { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Range(1, 24, ErrorMessage = "Value has to be between 1 - 24")]
        [Column("Period")] public int Period { get; set; } = 0;

        [Range(0, 100, ErrorMessage = "Please enter valid integer Number")]
        [AllowNull]
        [Column("Quantity")] public int? Quantity { get; set; } = null;

        [Range(0, 1000, ErrorMessage = "Please enter valid doubleNumber less than 1000")]
        [AllowNull]
        [Column("Price")] public double? Price { get; set; } = null;
    }
}
