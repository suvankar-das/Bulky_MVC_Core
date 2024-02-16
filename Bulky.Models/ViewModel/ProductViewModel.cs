using Bulky.Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Bulky.Models.ViewModel
{
    public class ProductViewModel
    {
        [ValidateNever]
        [BindProperty]
        public Product Product { get; set; }
        [ValidateNever]
        [BindProperty]
        public IEnumerable<SelectListItem> CategoryList { get; set; }

    }
}
