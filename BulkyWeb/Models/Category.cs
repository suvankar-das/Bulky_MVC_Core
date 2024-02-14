using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        // all the properties that we define , should be the column of that table named category

        /* By default, if the name is purely ID,entity frameowrk 
         core will automatically think that this is the primary key for this table.
        But You should always use Key data annotation if the property name is other than Id, lets say ctaegory__id

        So If property name is Id or CategoryId , then EF will think as primary key.
        */

        [Key]
        public int Id { get; set; }
        [Required]
        // With Required data annotation , in table this column should have not null 

        [DisplayName("Category Name")]
        public string Name { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
