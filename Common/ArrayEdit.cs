using System;
using System.Linq;

namespace Common
{
    public static class ArrayEdit
    {
        public static string[] ArraySortWithExceptDuplication(String[] strArray)
        {
            try
            {
                Array.Sort(strArray);

                return (string[])strArray.Distinct();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
