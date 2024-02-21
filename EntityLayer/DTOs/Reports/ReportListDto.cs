using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.DTOs.Reports
{
    public class ReportListDto
    {
        public IList<Report> Reports { get; set; }

        public virtual int CurrentPage { get; set; } = 1; // İlk basta yani varsayilan 1. sayfada olsun
        public virtual int PageSize { get; set; } = 6; // Bir sayfada 6 adet haber gosterilsin

        public virtual int TotalCount { get; set; }
        public virtual int TotalPages => (int)Math.Ceiling(decimal.Divide(TotalCount, PageSize)); // Toplam kac sayfa olmasi gerektigini Toplam haber sayisini, bir sayfada olmasi gereken haber sayisina bolere buluyoruz.
        // Ceiling metodu da her zaman yukari yuvarlar

        public virtual bool ShowPrevious => CurrentPage > 1;  // Su an bulunan sayfa 1'den buyukse onceki butonu goster (ornegin 3. sayfada isek 1 ve 2 butonlarini gosterecek)
        public virtual bool ShowNext => CurrentPage < TotalPages;
        public virtual bool IsAscending { get; set; } = false; // Artan bicimde siralanacak mi?

    }
}
