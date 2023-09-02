using System;
using System.Collections.Generic;
using System.Text;

namespace EP.Srv.Cliente.Infrastructure.Extensions.Pagination
{
    public class PaginationResponse<TEntity>
    {
        public PaginationResponse()
        {
        }
        public PaginationResponse(TEntity data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }
        public TEntity Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
    }
}
