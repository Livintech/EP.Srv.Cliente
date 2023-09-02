using System;
using System.Collections.Generic;
using System.Text;

namespace EP.Srv.Cliente.Infrastructure.Extensions.Pagination
{
    public class PagedResponse<TEntity> : PaginationResponse<TEntity>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public PagedResponse(TEntity data, int totalRecords, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
            this.Succeeded = true;
            this.Errors = null;
            this.TotalRecords = totalRecords;
        }
    }
}
