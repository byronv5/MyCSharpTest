using System;
using System.Collections.Generic;
using System.Text;

namespace StructTest
{
    interface IPerson
    {
        void GetSex();//接口中的方法不允许public、private等修饰符
    }
}