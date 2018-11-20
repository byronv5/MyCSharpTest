using System;

namespace AbstractFactory
{
    public abstract class AbstractYelllowHuman : IHuman
    {
        /// <summary>
        /// 性别由子类实现，java的抽象类并不要求必须实现
        /// </summary>
        /// <returns></returns>
        public abstract string GetSex();


        public string GetSkinColor()
        {
            return "黄皮肤";
        }

        public string Talk()
        {
            return "中国话";
        }
    }
}
