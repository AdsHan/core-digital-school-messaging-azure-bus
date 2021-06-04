using System.Collections.Generic;
using System.Linq;

namespace MED.Core.Utils
{
    public static class ListUtils
    {
        public static bool isEmpty(object list)
        {

            List<object> listO = ((IEnumerable<object>)list).ToList();

            return listO.Count == 0;

        }
    }
}