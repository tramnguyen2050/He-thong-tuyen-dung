//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hethong_tuyendung.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CongViec
    {
        public CongViec()
        {
            this.NTD_CongViec = new HashSet<NTD_CongViec>();
        }
    
        public int Ma_CV { get; set; }
        public string Ten_CV { get; set; }
        public string Ma_NN { get; set; }
        public string ChucVu { get; set; }
        public string LoaiCV { get; set; }
        public string KinhNghiem { get; set; }
        public string NgonNgu { get; set; }
        public string MoTa { get; set; }
    
        public virtual CongViec CongViec1 { get; set; }
        public virtual CongViec CongViec2 { get; set; }
        public virtual ICollection<NTD_CongViec> NTD_CongViec { get; set; }
    }
}
