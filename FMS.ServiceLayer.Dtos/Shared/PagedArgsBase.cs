﻿namespace FMS.ServiceLayer.Dtos
{
    public abstract class PagedArgsBase
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
