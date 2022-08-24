using System;

namespace GPUI_UWPTS.Core.Models
{
    public class GPData
    {
        public string DataName { get; set; }

        public string Account { get; set; }

        private string EncPassWord { get; set; }

        public string WebsiteUrl { get; set; }

        public string ReservedData { get; set; }

        public DateTime UpdateTime { get; set; }

        public GPData()
        {
            DataName = "GPData_dataname";
            Account = "GPData_account";
            EncPassWord = null;
            WebsiteUrl = null;
            ReservedData = null;
            UpdateTime = DateTime.Now;
        }
    }
}
