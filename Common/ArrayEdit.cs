using System;
using System.Collections;

namespace Common
{
    /// <summary>
    /// 配列編集
    /// </summary>
    public static class ArrayEdit
    {
        /// <summary>
        /// 並べ替えと重複要素の削除
        /// </summary>
        /// <param name="strArray"></param>
        /// <returns></returns>
        public static string[] ArraySortWithExceptDuplication(String[] strArray)
        {
            string[] ret = null;

            try
            {
                Array.Sort(strArray);

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
