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
    
    public partial class Driver
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Driver()
        {
            this.Contact = new HashSet<Contact>();
        }
    
        public int DriverID { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public Nullable<System.DateTime> Birth { get; set; }
        public string Phone { get; set; }
        public string IDCard { get; set; }
        public Nullable<int> FK_TeamID { get; set; }
        public Nullable<byte> State { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CheckInTime { get; set; }
        public Nullable<byte> IsDelete { get; set; }
        public Nullable<System.DateTime> AlterTime { get; set; }

        public string BeginBirth { get; set; }
        public string EndBirth { get; set; }
        public string BeginInTime { get; set; }
        public string EndInTime { get; set; }
        public string Number { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual TruckTeam TruckTeam { get; set; }
        public string SexName { get; set; }
        public int TruckID { get; set; }
        public string TeamName { get; set; }
    }
}
