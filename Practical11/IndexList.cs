using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;
using System.IO;

namespace Practical11
{
    internal class IndexList
    {
        ArrayList indexlist;
        int sortedState = 0;

        public IndexList()
        {
            indexlist = new ArrayList();
         
        }
        private void Swop(int swop1,int swop2)
        {
            IndexTatient cur = (IndexTatient)indexlist[swop2];
            indexlist[swop2] = indexlist[swop1];
            indexlist[swop1] = cur;
        }
        private void SelectionSort()
        {
            int minPos = 0;
            for (int pass = 1;pass < indexlist.Count;pass++)
            {
                for (int compare = pass;compare < indexlist.Count;compare++)
                {
                    IndexTatient first = (IndexTatient)indexlist[compare];
                    IndexTatient second = (IndexTatient)indexlist[minPos];
                    if (first.GetNum() < second.GetNum())
                        minPos = compare;
                }
                Swop(pass - 1,minPos);
                minPos = pass;
                
            }
        }
        public void Selection()
        {
            SelectionSort();
            sortedState = 1;
        }
        public void InsertedSort(IndexTatient Newone, int last)
        {
            int curPos = last;
            IndexTatient cur = (IndexTatient)indexlist[curPos];
            while ((curPos != -1) && (Newone.GetNum().CompareTo(cur.GetNum()) < 0))
            {
                curPos--;
                if (curPos != -1)
                    cur = (IndexTatient)indexlist[curPos];
            }
            indexlist.Insert(curPos + 1, Newone);
            
        }

        public void AddIndex(IndexTatient Newone)
        {
            if (sortedState == 1)
            {
                int Last = indexlist.Count - 1;
                InsertedSort(Newone, Last);
            }
            else
            {
                indexlist.Add(Newone);
                sortedState = 0;
            }
        }
        public void Delete(int pos)
        {
            indexlist.RemoveAt(pos - 1);
        }
        public void Displayall()
        {
            for (int i = 0;i < indexlist.Count; i++)
            {
                IndexTatient cur = (IndexTatient)indexlist[i];
                cur.Displaypatient();
            }
        }
        private int BinarySearchNum(int num)
        {
            int first = 0;
            int last = indexlist.Count - 1;
            while (first <= last)
            {
                int mid = (first + last) / 2;
                IndexTatient cur = (IndexTatient)indexlist[mid];
                if (cur.GetNum() == num)
                    return mid;
                else if (num < cur.GetNum())
                    last = mid - 1;
                else
                    first = mid + 1;

            }
            return -1;
        }
        public int FindIndex(int num)
        {
            return BinarySearchNum(num) + 1;
        }
        public IndexTatient GetIndex(int pos)
        {
            pos--;
            if ((pos >= 0) && (pos <= indexlist.Count))
                return(IndexTatient)indexlist[pos];
            else 
                return null;
        }
    }
}
