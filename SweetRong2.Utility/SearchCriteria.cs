using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetRong2.Utility
{
    public class SearchCriteria
    {
        public enum SearchFieldType { Keyword, Price, RemainingTime }
        public string SearchKeyword { get; set; }
        public string SortByField { get; set; }
        public string PagingSize { get; set; }
        public int GetPageSize()
        {
            int result = 5;
            if (!string.IsNullOrEmpty(this.PagingSize))
                int.TryParse(this.PagingSize, out result);
            return result;
        }

        public SearchFieldType GetSortByField()
        {
            SearchFieldType result = SearchFieldType.Keyword;
            return result;
        }

    }
}
