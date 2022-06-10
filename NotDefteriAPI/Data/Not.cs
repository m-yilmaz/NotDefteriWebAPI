using System;
using System.ComponentModel.DataAnnotations;

namespace NotDefteriAPI.Data
{
    public class Not
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public DateTime? OlusturulmaTarihi { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }
    }
}
