namespace Common
{
    public static class MyExtention
    {
        /// <summary>
        /// ToString()升级版
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string TooString(this object obj)
        {
            return obj == null ? "" : obj.ToString();
        }
    }
}
