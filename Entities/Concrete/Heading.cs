using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Heading
    {
        [Key]
        public int HeadingId { get; set; }
        [StringLength(100)]
        public string HeadingName { get; set; }
        public DateTime HeadingDate { get; set; }
        public bool HeadingStatus { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; } // Kategori tarafında bir property oluşturarak ilişkilendirdik.

        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        public ICollection<Content> Contents { get; set; }



    }
}
