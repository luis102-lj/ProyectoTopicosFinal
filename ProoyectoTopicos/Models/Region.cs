using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProoyectoTopicos.Models
{
    public partial class Region
    {
        public Region()
        {
            Territories = new HashSet<Territories>();
        }

        [Required]
        [Display(Name ="Id de la region")]
        public int RegionId { get; set; }
        [Required]
        [Display(Name ="Region")]
        public string RegionDescription { get; set; }

        public virtual ICollection<Territories> Territories { get; set; }
    }
}
