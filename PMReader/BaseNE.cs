using System;
using System.Collections.Generic;
using System.Text;

namespace PMReader
{
    class BaseNE
    {
        public List<NE> NeList;

        public BaseNE()
        {
            NeList=new List<NE>();
        }

        public void AddNewNE(NE ne)
        {
            NeList.Add(ne);
        }
    }
}
