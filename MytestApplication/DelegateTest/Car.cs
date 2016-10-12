using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DelegateTest
{
    public class Car
    {
        public delegate void CarEvent(string msg, int result);

        private CarEvent _showMsg;

        public void SetDelegate(CarEvent target)
        {
            _showMsg = target;
        }

        public void Add(int x, int y)
        {
            if (_showMsg != null)
                _showMsg.Invoke("Adding has completed", x + y);
        }
    }
}
