using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PMReader
{
    class BaseNE
    {
        public delegate void addNeHandler(string name);
        public event addNeHandler AddingNE;
        public List<NE> NeList;

        public BaseNE()
        {
            NeList=new List<NE>();
        }

        private void AddNewNE(NE ne)
        {
            NeList.Add(ne);
         if(ne!=null &&!string.IsNullOrWhiteSpace(ne.NE_Name) && AddingNE!=null)   AddingNE(ne.NE_Name);
        }
        
        public List<NE> GetPM24()
        {
        	return NeList.Where(x => x.ISPM15 == false).ToList();
        }
                public List<NE> GetPM15()
        {
                	return NeList.Where(x => x.ISPM15).ToList();
        }
        /// <summary>
        /// Add New NE or New info in Existing Ne
        /// </summary>
        /// <param name="pm"></param>
        /// <returns>true if NE exist</returns>
        public bool AddNE(ReadPM pm)
        {int index= this.NeList.FindIndex(x => x.NE_Name == pm.NE_Name && x.ISPM15 ==false);
            if (index != -1)//Exist NE
            {
                this.NeList[index].AddInfo(pm);
                return true;
            }
            else
            {
                this.AddNewNE(new NE(pm));
                return false;
                
            }
        }
        //add info for pm15
        public bool AddNE(PM15 pm)
        {
            int index = this.NeList.FindIndex(x => x.NE_Name == pm.NE_Name && x.ISPM15);
            if (index != -1)//Exist NE
            {
                this.NeList[index].AddInfo(pm);
                return true;
            }
            else
            {
                this.AddNewNE(new NE(pm));
                return false;

            }
        }
    }

  
}
