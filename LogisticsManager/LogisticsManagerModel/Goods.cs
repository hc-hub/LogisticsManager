//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogisticsManagerModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Goods
    {
        public int GoodsID { get; set; }
        public string GoodsName { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<double> Weight { get; set; }
        public Nullable<double> Volume { get; set; }
        public Nullable<int> FK_CarriersID { get; set; }
        public Nullable<byte> IsDelete { get; set; }
    
        public virtual Carriers Carriers { get; set; }
    }
}