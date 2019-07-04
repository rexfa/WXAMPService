using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WXAMPService.CustomStructure
{
    [Serializable]
    public class MPItemData
    {
        public int itemId { set; get; }
        public string nikeName { set; get; }
        public string realName { set; get; }
        public string picURL { set; get; }
        /// <summary>
        /// 已获选票
        /// </summary>
        public int voted { set; get; }
    }
}
