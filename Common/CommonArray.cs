using System;
using System.Collections;

namespace Common
{
    public class CommonArray
    {
        public static string[] ArraySortWithExceptDuplication(String[] strArray)
        {
            string[] ret = null;

            try
            {
                System.Array.Sort(strArray);

                ArrayList arrayList = new ArrayList(strArray.Length);

                foreach (string i in strArray)
                {
                    if (!arrayList.Contains(i) && i != null)
                    {
                        arrayList.Add(i);
                    }
                }

                ret = (string[])arrayList.ToArray(typeof(string));

                return ret;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
