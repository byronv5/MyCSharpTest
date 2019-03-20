namespace Command
{
    public class DeletePageCommand : AbstractCommand
    {
        public override void Exeute()
        {
            pg.Find();
            pg.Delete();
            pg.Plan();
        }
    }
}
