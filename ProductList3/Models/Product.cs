using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductList3.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Product Name")]
        public string ProductName { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Expiry Time")]
        public DateTime ExpiryTime { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Registration Date and Time")]
        public DateTime RegistrationTime { get; set; }

        

        public Product()
        {
            this.RegistrationTime = DateTime.Now;
            
        }
    }
}
