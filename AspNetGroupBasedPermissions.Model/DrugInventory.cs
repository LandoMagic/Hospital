using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetGroupBasedPermissions.Model
{
    public class DrugInventory
    {
        [Key]
        public int Id { get; set; }
        public string DrugGenericName { get; set; }
        public string DrugBrandName { get; set; }
        //how much ex: 44mg
        public string Strength { get; set; }
        [Display(Name = "Patient")]
        public string ApplicationUserId { get; set; }
        public string DosageForm { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int BatchNumber { get; set; }
      //  public int Id { get; set; }
        //in stock
        public string Stock { get; set; }

        public DateTime DateReceived { get; set; }
        public int StockQuantity { get; set; }
        public string MainCategory { get; set; }


    }
}
