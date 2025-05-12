using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Practical11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            PatientList Patints = new PatientList("PatientData.txt");
            IndexList patientnumList = new IndexList();

            Patints.BuidIndex(patientnumList);

            DisplayOptions(Patints);
            int choice = int.Parse(ReadLine());
            ProcessOption(Patints, choice,patientnumList);
            while (choice != 8)
            {
                DisplayOptions(Patints);
                choice = int.Parse(ReadLine());
                ProcessOption(Patints, choice,patientnumList);

            }
            Patints.Close();
            ReadLine();






        }

        static void DisplayOptions(PatientList patients)
        {
            WriteLine("Choose one of the following options: ");
            WriteLine("1. Add a patient");
            WriteLine("2. Delete a patient");
            WriteLine("3. Display patient details");
            WriteLine("4. Update patient balance ");
            WriteLine("5. Display records with outstanding balance above...");
            WriteLine("6. Display all patients ");
            WriteLine("7. Display the objects in the IndexList");
            WriteLine("8. Save data and quit");
            Write("Choice: ");
        }
        static void ProcessOption(PatientList patient, int choice,IndexList numList )
        {
            WriteLine();

            switch (choice)
            {
                case 1:
                     AddPatient(patient,numList);
                    WriteLine();
                    break;
                case 2:
                    DeletePatient(patient,numList);
                    WriteLine();
                    break;
                case 3:
                   DisplaybookDetail(patient,numList);
                    WriteLine();
                    break;
                case 4:
                    //add method call(s) as needed
                    AbovePatient(patient);
                    WriteLine();
                    break;
                case 5:
                    //add method call(s) as needed
                   
                    WriteLine();
                    break;
                case 6:
                    //add method call(s) as needed
                    DisplayAll(patient);
                    WriteLine();
                    break;
                case 7:
                    DisplayIndex(numList);
                    //add method call(s) as needed
                  
                    WriteLine();
                    break;
                default:
                    WriteLine("Goodbye, the data will now be written to the text file");
                    break;
            }
        }
        static void AbovePatient(PatientList patients)
        {
            patients.DisplayAbove();
        }
        static void AddPatient(PatientList patients,IndexList patientList)
        {
            Write("Enter patient number :");
                int num = int.Parse(ReadLine());
            Write("Enter your Surname : ");
            string sur = ReadLine();
            Write("Enter initials :");
            string ini = ReadLine();
            Write("Enter yout balance");
            double bal = double.Parse(ReadLine());
            Patient Newone = new Patient(num, sur, ini, bal);
            patients.AddPa(Newone,patientList);
            WriteLine("The book was added. ");
        }
        static void DeletePatient(PatientList patient,IndexList numlist)
        {
            
            
                Write("Enter the Patient number: ");
                int want = int.Parse(Console.ReadLine());
                int pos = numlist.FindIndex(want);
                if (pos == 0)
                    WriteLine("This Book was not found");
                else
                {
                    numlist.Delete(pos);
                    
                    WriteLine("This Book has been removed");
                }
           
            patient.DeletePos(pos);
            
        }
        static void DisplaybookDetail(PatientList patient , IndexList numList)
        {
            Write("Patient num: ");
            int num = int.Parse(ReadLine());
            int indexpos = numList.FindIndex(num);
            if (indexpos == 0)
                WriteLine("The book does not exist. ");
            else
            {
                IndexTatient currentindex = numList.GetIndex(indexpos);
                int patientpos = currentindex.GetPos();
                Patient cur = patient.GetPatient(patientpos + 1);
                cur.DisplayPatient();
            }
        }
        static void DisplayAll(PatientList patient)
        {
            patient.Displayall();
        }
        static void DisplayIndex(IndexList numList)
        {
            numList.Displayall();
        }
    }
}
