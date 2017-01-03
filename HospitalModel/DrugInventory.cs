using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalModel
{
    public class DrugInventory
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string DrugGenericName { get; set; }

        [Display(Name = "Brand Name")]
        public string DrugBrandName { get; set; }
        //how much ex: 44mg
        public string Strength { get; set; }

        [Display(Name = "Patient")]
        public string ApplicationUserId { get; set; }

        [Display(Name = "Dosage")]
        public string DosageForm { get; set; }

        public DateTime ExpiryDate { get; set; }

        [Display(Name = "Batch Number")]
        public int BatchNumber { get; set; }
      //  public int Id { get; set; }
        //in stock
        public string Stock { get; set; }

        [Display(Name = "Date Received")]
        public DateTime DateReceived { get; set; }

        [Display(Name = "Stock Quantity")]
        public int StockQuantity { get; set; }

        [Display(Name = "Main Category")]
        public string MainCategory { get; set; }


    }
}
