﻿using AppleStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleStoreIAL
{
    public interface ICategory
    {
        List<TheLoai> GetAllCategory();
        List<SanPham> GetProduct();
        IEnumerable<SanPham> GetAllByCategoryId(string id);
        IEnumerable<SanPham> SortByDonGia(string sortOrder);
    }
}
