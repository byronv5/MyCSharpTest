using System;

namespace Factory.HumanCreate
{
    public class WhiteMan : IHuman
    {
        public string GetColor()
        {
            return "白人";
        }

        public string Talk()
        {
            return "英语听得懂?";
        }
    }
}
