using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkApiTest.Utils
{
    public static class StringUtil
    {
        public static string CutReference(string reference) 
        {
            return reference.Remove(0, reference.LastIndexOf('/')+1);
        }
    }
}
