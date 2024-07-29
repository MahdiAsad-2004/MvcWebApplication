using OrganicShop.Domain.Entities;
using OrganicShop.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Dtos.Page
{
    public class Pager
    {
        public int CurrentPage { get; set; }
        public int PageItemCount { get; set; }
        public int PageShowAfterAndBeforeCurrent { get; set; }
        public int AllItemsCount { get; private set; }
        public int PageItemNumberStart { get; private set; }
        public int PageItemNumberEnd { get; private set; }
        public int LastPageNumber { get; private set; }

        public string PageStatus()
        {
            //return $"نمایش از {PageItemNumberStart} تا {PageItemNumberEnd} از {AllItemsCount} مورد";
            return $"Sohwing page {PageItemNumberStart} to {PageItemNumberEnd} items from {AllItemsCount} items";
        }


        //public Pager(int PageNumber, int PageItemCount, IQueryable<Entity> query)
        //{
        //    CurrentPage = PageNumber;
        //    this.PageItemCount = PageItemCount;
        //    AllItemsCount = query.Count();
        //    PageItemNumberEnd = AllItemsCount > PageItemCount ? (PageItemCount * PageNumber) : AllItemsCount;
        //    PageItemNumberStart = ((PageNumber - 1) * PageItemCount) + 1;
        //    LastPageNumber = AllItemsCount % PageItemCount == 0 ? (AllItemsCount / PageItemCount) : (AllItemsCount / PageItemCount) + 1;
        //}

        public void SetPager<Entity>(PagingDto? paging, IQueryable<Entity> query) where Entity : IAggregateRoot
        {
            if (paging == null)
            {
                CurrentPage = 1;
                this.PageItemCount = query.Count();
                AllItemsCount = this.PageItemCount;
                PageItemNumberEnd = 1;
                PageItemNumberStart = this.PageItemCount;
                LastPageNumber = 1;
            }
            else
            {
                CurrentPage = paging.PageNumber;
                this.PageItemCount = paging.PageItemsCount;
                AllItemsCount = query.Count();
                PageItemNumberEnd = AllItemsCount > paging.PageItemsCount ? (paging.PageItemsCount * paging.PageNumber) : AllItemsCount;
                PageItemNumberStart = ((paging.PageNumber - 1) * paging.PageItemsCount) + 1;
                LastPageNumber = AllItemsCount % paging.PageItemsCount == 0 ? (AllItemsCount / paging.PageItemsCount) : (AllItemsCount / paging.PageItemsCount) + 1;
            }
        }



        //public void SetPager<Entity>(IQueryable<Entity> query) where Entity : IAggregateRoot
        //{
        //    CurrentPage = 1;
        //    this.PageItemCount = query.Count();
        //    AllItemsCount = this.PageItemCount;
        //    PageItemNumberEnd = 1;
        //    PageItemNumberStart = this.PageItemCount;
        //    LastPageNumber = 1;
        //}



        //public Pager(int PageNumber, int PageItemCount, int AllItemsCount)
        //{
        //    this.AllItemsCount = AllItemsCount;
        //    PageItemNumberEnd = AllItemsCount > PageItemCount ? (PageItemCount * PageNumber) : AllItemsCount;
        //    PageItemNumberStart = (PageNumber - 1) * PageItemCount + 1;
        //    LastPageNumber = AllItemsCount % PageItemCount == 0 ? (AllItemsCount / PageItemCount) : (AllItemsCount / PageItemCount) + 1;
        //}
    }
}
