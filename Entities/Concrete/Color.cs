using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    class Color :ICar
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
    }
}
