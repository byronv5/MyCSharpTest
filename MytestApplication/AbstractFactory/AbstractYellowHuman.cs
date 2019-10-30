using System;

namespace AbstractFactory
{
    public abstract class AbstractYelllowHuman : IHuman
    {
        /// <summary>
        /// 性别由子类实现，但是java的抽象方法不强制子类实现
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
