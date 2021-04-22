using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Aapartment.Business.Config
{
    public static class PagingExtension
    {
        public static IQueryable<T> Paging<T,L>(this IQueryable<T> list, int pagesize, int page, Func<T, L> predicate)
        {
            return list.OrderBy(a => predicate(a)).Skip(pagesize * page).Take(pagesize);
        } 
    }
}
