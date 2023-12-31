﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EP.Srv.Cliente.Infrastructure.Extensions.Pagination
{
    public class PaginationFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        //public FiltroTextoBreveDTO? filtroTextoBreve { get; set; }
        //public FiltroManualDTO? filtroManual { get; set; }

        public PaginationFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
