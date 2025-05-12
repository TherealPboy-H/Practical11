using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical11
{
    internal class IndexTatient
    {
        int num;
        int pos;

        public IndexTatient(int num,int pos)
        {
            this.num = num;
            this.pos = pos;
        }
        public int GetNum()
        {
            return num;
        }
        public int GetPos()
        {
            return pos;
        }

        public void Displaypatient()
        {
            Console.WriteLine("{0}  {1} ",num,pos + 1 );
        }
        
    }
}
