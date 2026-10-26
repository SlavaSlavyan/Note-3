using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    /// <summary>
    /// Информационный товар
    /// </summary>
    internal class DigitalProduct : Product
    {
        public DigitalProduct(string initName, float initWeight, Money initPrice) : base(initName, initWeight, initPrice) { }
    }
}
