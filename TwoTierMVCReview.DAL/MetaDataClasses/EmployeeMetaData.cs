using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//don't forget to change the namespace!
namespace TwoTierMVCReview.DAL
{
    public class EmployeeMetaData
    {
        //If we tell the system not to scaffold the first and last names
        //it will be more difficult to populate the fields.  We only
        //want to avoid scaffolding the UserID so no one can accidentally 

        [Required(ErrorMessage ="* First Name is Required")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "* Last Name is Required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [ScaffoldColumn(false)]
        public Nullable<System.Guid> UserID { get; set; }

        public string Position { get; set; }

        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,14}$", ErrorMessage ="* Incorrect Email format")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public bool Status { get; set; }

        [Display(Name="Employee")]
        public string FullName
        { get; }
    }

    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
        //use the propfull!
        public string FullName
        {
            get { return FirstName + " " + LastName; }
            
        }

    }
}
