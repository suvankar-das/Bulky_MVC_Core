using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        // With Required data annotation , in table this column should have not null 

        [DisplayName("Product Title")]
        public string Title { get; set; }

        [DisplayName("Product ISBN")]
        public string ISBN { get; set; }

        [DisplayName("Product Author")]
        public string Author { get; set; }

        [DisplayName("Category Select")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        
        [ValidateNever]
        public Category Category { get; set; }
    }
}
