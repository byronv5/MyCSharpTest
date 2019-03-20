namespace Command
{
    /// <summary>
    /// 抽象命令基类
    /// </summary>
    public abstract class AbstractCommand
    {
        protected RequirementGroup rg = new RequirementGroup();
        protected PageGroup pg = new PageGroup();
        protected CodeGroup cg = new CodeGroup();

        public abstract void Exeute();
    }
}
