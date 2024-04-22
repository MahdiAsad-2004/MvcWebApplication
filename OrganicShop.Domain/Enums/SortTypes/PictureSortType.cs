using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.Domain.Enums.SortTypes
{
    public enum PictureSortType
    {
        None,

        Newest,

        LatestChange,

        Oldest,


        Size,

        SizeDesc,
    }
}
