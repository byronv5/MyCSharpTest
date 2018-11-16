namespace Factory.HumanCreate
{
    class YellowMan : IHuman
    {
        public string GetColor()
        {
            return "黄色人";
        }

        public string Talk()
        {
            return "讲中国话";
        }
    }
}
