using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
        
        public List<NE> GetPM24()
        {
        	return NeList.Where(x => x.ISPM15 == false).ToList();
        }
                public List<NE> GetPM15()
        {
                	return NeList.Where(x => x.ISPM15).ToList();
        }
    }
}
