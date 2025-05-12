using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical11
{
    internal class Patient
    {

        int PNum;
        string PSurname;
        string PInitials;
        double PBalance;

        public Patient(int PNum, string PSurname, string PInitials, double PBalance)
        {
            this.PNum = PNum;
            this.PSurname = PSurname;
            this.PInitials = PInitials;
            this.PBalance = PBalance;
        }
        public Patient(double PBalance)
        {
            this.PBalance = PBalance;
        }
      
        public int GetNum()
        {
            return PNum;
        }

        public string GetSur()
        {
            return PSurname;
        }
        public string GetIn()
        {
            return PInitials;
        }
        public double GetBal()
        {
            return PBalance;
        }
        public void SetSur(string Sur)
        {
            PSurname = Sur;
        }
        public void SetIni(string Ini)
        {
            PInitials = Ini;
        }
        public void SetBal(double bal)
        {
            PBalance = bal;
        }
        public void DisplayPatient()
        {

            Console.WriteLine("Patient: {0}  Surname: {1} Name: {2}", PNum, PSurname, PInitials);

            Console.WriteLine("     Balance: {0}", PBalance);
        }
        public bool DisplayHighcars()
        {
            if (PBalance >= 500)
                return true;
            else
                return false;
        }
    }
}
