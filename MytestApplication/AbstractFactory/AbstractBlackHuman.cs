namespace AbstractFactory
{
    public abstract class AbstractBlackHuman : IHuman
    {
        /// <summary>
        /// 性别由子类实现，java的抽象类并不要求必须实现
        /// </summary>
        /// <returns></returns>
        public abstract string GetSex();


        public string GetSkinColor()
        {
            return "黑皮肤";
        }

        public string Talk()
        {
            return "非洲话";
        }
    }
}
