namespace Adapter
{
    /// <summary>
    /// 适配器角色:继承源角色类，并根据源角色逻辑实现目标角色接口
    /// </summary>
    class AdapterRole : Adaptee, ITarget
    {
        public void Excute()
        {
            base.DoSomething();
        }
    }
}
