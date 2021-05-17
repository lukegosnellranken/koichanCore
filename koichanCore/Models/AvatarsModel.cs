using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace koichanCore.Models
{
    public class AvatarsModel
    {
        [Key]
        public int ImageID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Title {get; set;}

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }
    }
}
