using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    /// <summary>
    /// Физический товар
    /// </summary>
    internal class PhysicalProduct : Product
    {
        public PhysicalProduct(string initName, float initWeight, Money initPrice) : base(initName, initWeight, initPrice) 
        { 
            _isDeliveryNeeded = true; 
        }
    }
}
