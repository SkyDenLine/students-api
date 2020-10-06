using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Domain.Models
{
    public class PageRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
