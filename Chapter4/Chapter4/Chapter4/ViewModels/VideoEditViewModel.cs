using Chapter4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4.ViewModels
{
    public class VideoEditViewModel
    {
        public int id { get; set; }

        [Required, MinLength(3), MaxLength(80)]
        public string Title { get; set; }

        [Display(Name ="Film Genre")]
        public Genres Genre { get; set; }
    }
}
