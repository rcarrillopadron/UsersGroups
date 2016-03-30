using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UsersGroups.Web.Models
{
    public class Prize
    {
        public int PrizeId { get; set; }

        [Required]
        public string PrizeDescription { get; set; }

        public virtual ICollection<Winner> Winners { get; set; } = new HashSet<Winner>();
    }
}