using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KK.WX
{
    public class WXBase
    {

        public string ToDebugString()
        {
            String result = String.Empty;
            System.Reflection.PropertyInfo[] pros = this.GetType().GetProperties();
            if (pros != null && pros.Length > 0)
            {
                foreach(System.Reflection.PropertyInfo pro in pros)
                {
                    result += "[" + pro.Name;
                    Object val = pro.GetValue(this);
                    if (val != null)
                    {
                        result += ":" + val.ToString() + "]";
                    }
                    else
                    {
                        result += ":null]";
                    }
                }
            }
            return result;
        }

    }
}
