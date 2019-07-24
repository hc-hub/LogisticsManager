using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticsManagerModel
{
    public class Users
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Sex { get; set; }
        public int SexId { get; set; }
        public string Account { get; set; }
        public string PassWord { get; set; }
        public string NewPwd { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int FK_RoleID { get; set; }
        public DateTime CheckInTime { get; set; }
        public string IsDelete { get; set; }
        public DateTime AlterTime { get; set; }
        public string EndInTime { get; set; }
        public string BeginInTime { get; set; }
        public string UpdateBeginTime { get; set; }
        public string UpdateEndTime { get; set; }
        public string RoleName { get; set; }
    }
}
