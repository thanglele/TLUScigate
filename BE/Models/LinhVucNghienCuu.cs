using Microsoft.AspNetCore.Mvc;

namespace TLUScience.Models
{
    public class LinhVucNghienCuu
    {
        public int ID { get; set; }
        public string TenLinhVuc { get; set; }
        public string? MoTa { get; set; }

        //public ICollection<GiangVien_LinhVuc> giangVien_LinhVucs { get; set; }
    }
}
