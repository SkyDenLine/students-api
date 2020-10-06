using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Domain.Models
{
    public class PageResponse<TData>
    {
        public int PagesCount { get; set; }
        public List<TData> PageData { get; set; }
    }
}
