using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT_Mat_Discreta_Allan_Greffin
{
    public interface IPrintable
    {
        int Id { get; set; }
        void Print();
    }
}
