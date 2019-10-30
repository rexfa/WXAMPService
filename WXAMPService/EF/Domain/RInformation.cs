using WXAMPService.EF;

namespace WXAMPService.EF.Domain
{
    public class RInformation :BaseEntity
    {
        public string username { get; set; }
        public string wxid { get; set; }
        public string wxname { get; set; }
        public string userinfo { get; set; }
        public int rank { get; set; }
        public int votes { get; set; }

    }
}
