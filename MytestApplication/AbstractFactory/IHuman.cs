using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractFactory
{
    public interface IHuman
    {
        string GetSkinColor();
        string Talk();
        string GetSex();
    }
}
