using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WXAMPService.CustomStructure;
using WXAMPService.Infrastructures;

namespace WXAMPService.Simulation
{
    public class ItemListData
    {
        public static string GenerateSimulationDataToJson(int id)
        {
            List<MPItemData> list = new List<MPItemData>();
            MPItemData itemData0 = new MPItemData()
            {
                itemId = 0,
                nikeName = "xiaozhao",
                picURL = "https://img14.360buyimg.com/n0/jfs/t1/50726/15/1257/215083/5cef90f6Efef722f6/acc3a18650404548.jpg",
                realName = "小赵",
                voted = 229
            };
            list.Add(itemData0);
            MPItemData itemData1 = new MPItemData()
            {
                itemId = 1,
                nikeName ="xiaowang",
                picURL= "https://img14.360buyimg.com/n0/jfs/t1/50726/15/1257/215083/5cef90f6Efef722f6/acc3a18650404548.jpg",
                realName = "小王",
                voted = 321
            };
            list.Add(itemData1);
            MPItemData itemData2 = new MPItemData()
            {
                itemId = 2,
                nikeName = "xiaoli",
                picURL = "http://img.redocn.com/sheji/20171018/tiqianyifenzhongweixinxiaogushichangtu_8171981.jpg",
                realName = "小李",
                voted = 124
            };
            list.Add(itemData2);
            MPItemData itemData3 = new MPItemData()
            {
                itemId = 3,
                nikeName = "xiaowei",
                picURL = "http://img.redocn.com/sheji/20171018/tiqianyifenzhongweixinxiaogushichangtu_8171981.jpg",
                realName = "小魏",
                voted = 224
            };
            list.Add(itemData3);
            MPItemData itemData4 = new MPItemData()
            {
                itemId = 4,
                nikeName = "xiaozhang",
                picURL = "http://img.redocn.com/sheji/20171018/tiqianyifenzhongweixinxiaogushichangtu_8171981.jpg",
                realName = "小张",
                voted = 624
            };
            list.Add(itemData4);

            return SerializationHandle.SerializeMPItemDataList(list);
        }

    }
}
