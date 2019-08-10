using LibraryManagementSystem_A2.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryManagementSystem_A2.Models
{
    public class Book
    {
        public virtual int BookId { get; set; }

        [Required]
        public virtual int Isbn { get; set; }

        [Required]
        public virtual string Title { get; set; }

        [Required]
        public virtual int Year { get; set; }

        [MaxWords(3)]
        public virtual string Author { get; set; }

        [DisplayName("(Optional) Image Path ")]
        public virtual string ImageUrl { get; set; }

        public virtual string Photo { get { return ImageUrl == null ? "~/Content/Images/default.png" : ImageUrl; } }

        public virtual LibraryBranch Location { get; set; }
    }
}