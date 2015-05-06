using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EShop.Model
{
    [Serializable]
    public class BaseParameter
    {
        public Dictionary<string, object> KeyValues = new Dictionary<string, object>();

    }
}
