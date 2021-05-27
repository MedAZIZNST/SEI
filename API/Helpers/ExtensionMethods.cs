using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Solution.Entities;
using Solution.Service;

namespace API.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users) {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user) {
            user.Pwd = null;
            return user;
        }

        public static IList<object> EmumTojson(this Type e)
        {
                var enumVals = new List<object>();

                foreach (var item in Enum.GetValues(e))
                {

                    enumVals.Add(new
                    {
                        value = (int)item,
                        text = item.ToString()
                    });
                }
                return enumVals;
        }
        
        public static string HashSHA256(this string value)
        {
            var HashSHA256 = System.Security.Cryptography.SHA256.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value + "MySecretKeyForJWTTokenEncryption");
            var hash = HashSHA256.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            { 
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Extension method to add pagination info to Response headers
        /// </summary>
        /// <param name="response"></param>
        /// <param name="currentPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="totalItems"></param>
        /// <param name="totalPages"></param>
        public static void AddPagination(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);

            response.Headers.Add("Pagination",
                Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));
            // CORS
            // response.Headers.Add("access-control-expose-headers", "Pagination");
        }

        public static PaginationRequest GetPagination(this HttpRequest request)
        {
            var currentpage = request.Query["currentpage"];
            var itemsPerPage = request.Query["itemsPerPage"];
            var orderBy = request.Query["orderBy"];
            var sortOrder = request.Query["sortOrder"];
            var filterBy = request.Query["filterBy"];
            var filterValue = request.Query["filterValue"];
            var  paginationHeaderRq = new PaginationRequest();
            if (!string.IsNullOrEmpty(currentpage))
            {
                int.TryParse(currentpage, out int _currentpage);
                paginationHeaderRq.CurrentPage = _currentpage;
            }
            if (!string.IsNullOrEmpty(itemsPerPage))
            {
                int.TryParse(itemsPerPage, out int _itemsPerPage);
                paginationHeaderRq.ItemsPerPage = _itemsPerPage;
            }
            if (!string.IsNullOrEmpty(sortOrder))
            {
                if (int.TryParse(sortOrder, out int _sortOrder) && (_sortOrder == 1 || _sortOrder == -1))
                {
                    paginationHeaderRq.SortOrder = _sortOrder;
                }
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                paginationHeaderRq.OrderBy = orderBy.ToString().ToLower();
            }
            if (!string.IsNullOrEmpty(filterBy))
            {
                paginationHeaderRq.FilterBy = filterBy.ToString().ToLower();
            }
            if (!string.IsNullOrEmpty(filterValue))
            {
                paginationHeaderRq.FilterValue = filterValue.ToString().ToLower();
            }

            return paginationHeaderRq;
        }
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            // CORS
            // response.Headers.Add("access-control-expose-headers", "Application-Error");
        }

    }
}