using System;
using System.Collections.Generic;
using System.Text;

namespace API.Helpers
{
   public class PaginationResponse
    {        
        public IEnumerable<Object> Items { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PaginationResponse(int currentPage, int itemsPerPage, int totalItems, int totalPages, IEnumerable<Object> items)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
            this.Items = items;
        }


        public PaginationResponse()
        {
        }
    }

    public class PaginationRequest
    {
        public int CurrentPage { get; set; } = 1;
        public int ItemsPerPage { get; set; } = 25;
        public string OrderBy { get; set; } = "id";
        public int SortOrder { get; set; } = -1;
        public string FilterBy { get; set; } = "global_filter";
        public string FilterValue { get; set; } = "";

        public PaginationRequest(int currentPage, int itemsPerPage, string orderBy, int sortOrder, string filterBy, string filterValue)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.OrderBy = orderBy;
            this.SortOrder = sortOrder;
            this.FilterBy = filterBy;
            this.FilterValue = filterValue;

        }

        public PaginationRequest()
        {
        }
    }
} 

