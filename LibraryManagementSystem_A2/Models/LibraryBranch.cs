using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem_A2.Models
{
    public class LibraryBranch
    {
        public virtual int LibraryBranchId { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string Address { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public virtual string Phone { get; set; }

        [Required]
        [DisplayName("Open From")]
        public virtual string Hours { get; set; }
    }
}