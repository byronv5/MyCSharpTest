namespace Command
{
    public class AddRequirementCommand : AbstractCommand
    {
        public override void Exeute()
        {
            rg.Find();
            rg.Add();
            rg.Plan();
        }
    }
}
