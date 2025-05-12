using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using static System.Console;

namespace Practical11
{
    internal class PatientList
    {
        ArrayList List;
        string filename;

        public PatientList(string file)
        {
            List = new ArrayList();
            filename = file;
            ReadData();
        }

        private void ReadData()
        {   
            StreamReader sr = new StreamReader(filename);
            char DELIM = ',';
            int num;
            string Surname;
            string Initials;
            double balance;
            string[] feilds;
            string dataline = sr.ReadLine();
            while (dataline != null)
            {
                feilds = dataline.Split(DELIM);
                num = int.Parse(feilds[0]);
                Surname = feilds[1];
                Initials = feilds[2];
                balance = double.Parse(feilds[3]);

                Patient cur = new Patient(num, Surname, Initials, balance);
                List.Add(cur);
                dataline = sr.ReadLine();

            }
            sr.Close();

        }
        private void WriteData()
        {
            StreamWriter sw = new StreamWriter(filename);
            for (int i =0;i < List.Count; i++)
            {
                Patient cur = (Patient)List[i];
                sw.Write(cur.GetNum() + ",");
                sw.Write(cur.GetSur() + ",");
                sw.Write(cur.GetIn() + ",");
                sw.Write(cur.GetBal() + ",");
                sw.WriteLine();
            }
            sw.Close();
        }
        public void Close()
        {
            WriteData();
        }
        public void AddPa(Patient newpa,IndexList PanumList)
        {
            List.Add(newpa);
            int num = newpa.GetNum();
            IndexTatient newindex = new IndexTatient(num, List.Count - 1);
            PanumList.AddIndex(newindex);
            
                
;        }
        public void DeletePos(int pos)
        {
            List.RemoveAt(pos - 1);
            
        }
        public void Displayall()
        {
            for (int x = 0; x < List.Count; x++)
            {
                Patient cur = (Patient)List[x];

                cur.DisplayPatient();
            }
        }
        public void DisplayBook(int Panum)
        {
            Patient cur = (Patient)List[Panum];
            cur.DisplayPatient();
        }
        public void BuidIndex(IndexList PatientIndexList)
        {
            // create index on patient num
            for (int x = 0;x < List.Count;x++)
            {
                Patient curpatient = (Patient)List[x];
                int num = curpatient.GetNum(); // get Patient number of current patient
                IndexTatient curIndex = new IndexTatient(num,x);
                   PatientIndexList.AddIndex(curIndex);
                
            }
            PatientIndexList.Selection();    // selection Sort
        }

        public Patient GetPatient(int pos)
        {
            pos--;
            if ((pos >= 0) && (pos <= List.Count))
                return (Patient)List[pos];
            else return null;
        }
        public void DisplayAbove()
        {
            bool decision = true;
            for (int i = 0; i < List.Count; i++)
            {
                Patient cur = (Patient)List[i];

                if (cur.DisplayHighcars() == decision )
                {
                    cur.DisplayPatient();
                }
                
                
                
            }
        }
    }
}
