using Microsoft.EntityFrameworkCore;
using SpaceInfosTracker.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInfosTracker.Common.Helpers
{
    public static class PagedListHelper
    {
        public static async Task<PagedResponseDto<T>> ToPagedListAsync<T>(this List<T> data, int pageSize, int pageIndex) where T : class
        {
            int totalCount = data.Count;
            int totalPage = totalCount / pageSize;
            var pagedData = new PagedResponseDto<T>()
            {
                CurrentPage = pageIndex,
                TotalPage = totalPage,
                PageSize = pageSize,
                TotalCount = totalCount
            };

            pagedData.Data = data.Skip(pageSize * pageIndex).Take(pageSize).ToList();
            return pagedData;
        }

    }
}
