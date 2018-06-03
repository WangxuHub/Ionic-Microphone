using System;
using System.Collections.Generic;
using System.Text;

namespace PhonemikeServer.Core
{
    public static class CommonHelper
    {
        public static string ToJsonString(this object obj)
        {
            try
            {
                var timeFormat = new Newtonsoft.Json.Converters.IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                };
                var jsonStr = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, timeFormat);
                return jsonStr;
            }
            catch
            {
                return "{}";
            }
        }
    }
}
