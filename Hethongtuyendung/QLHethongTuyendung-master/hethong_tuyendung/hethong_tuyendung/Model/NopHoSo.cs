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
    
    public partial class NopHoSo
    {
        public int Ma_NTD { get; set; }
        public int Ma_HS { get; set; }
        public System.DateTime NgayNop { get; set; }
        public string GhiChu { get; set; }
    
        public virtual HoSoXinViec HoSoXinViec { get; set; }
        public virtual NhaTuyenDung NhaTuyenDung { get; set; }
    }
}
