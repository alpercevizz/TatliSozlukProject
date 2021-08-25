﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        [StringLength(1000)]
        public string ContentText { get; set; }
        public DateTime ContentDate { get; set; }
        public bool ContentStatus { get; set; }

        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        public int? AuthorID { get; set; }
        public virtual Author Author { get; set; }
    }
}