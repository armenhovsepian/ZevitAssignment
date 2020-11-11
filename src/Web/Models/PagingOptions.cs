using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class PagingOptions
    {
        [Range(1, 1000)]
        public int? PageNumber { get; set; }
        [Range(1, 100)]
        public int? PageSize { get; set; }

        public int Take => PageSize ?? 10;
        public int Skip => PageNumber == null ? 0 : (PageNumber.Value - 1) * (PageSize ?? 10);
    }
}
