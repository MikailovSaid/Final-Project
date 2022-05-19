using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Utilities.Pagination
{
    public class Pagination<T>
    {
        public List<T> Datas { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;
        public Pagination(List<T> datas, int currentPage, int totalPage)
        {
            Datas = datas;
            CurrentPage = currentPage;
            TotalPage = totalPage;
        }
    }
}
