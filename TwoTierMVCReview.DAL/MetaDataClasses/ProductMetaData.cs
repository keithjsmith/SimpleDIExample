using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;//for data annotations
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoTierMVCReview.DAL
{
    public class ProductMetaData
    {
        [Required(ErrorMessage = "* Product Name is Required")]
        [Display(Name = "Product Name")]
        public string ProdName { get; set; }

        [Required(ErrorMessage = "* Description is Required")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = false)]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Picture")]
        public string ImageURL { get; set; }

        public Nullable<int> CategoryID { get; set; }
        public int ProdStatusID { get; set; }
        public Nullable<int> VendorID { get; set; }
    }

    [MetadataType(typeof(ProductMetaData))]
    public partial class WGProduct
    {}
}
