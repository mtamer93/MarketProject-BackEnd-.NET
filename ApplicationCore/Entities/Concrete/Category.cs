using ApplicationCore.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Concrete
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(750)]
        [MinLength(2)]
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
