using Newtonsoft.Json;
using System.Collections.Generic;
using WXAMPService.CustomStructure;

namespace WXAMPService.Infrastructures
{
    public class SerializationHandle
    {
        public static MPItemData DeserializeMPItemData(string json)
        {
            MPItemData mpItemData = JsonConvert.DeserializeObject<MPItemData>(json);
            return mpItemData;
        }
        public static string SerializeMPItemData(MPItemData mpItemData)
        {
            return JsonConvert.SerializeObject(mpItemData);
        }
        public static string SerializeMPItemDataList(List<MPItemData> mpItemDataList)
        {
            return JsonConvert.SerializeObject(mpItemDataList);
        }




    }
}
