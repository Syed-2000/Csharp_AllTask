using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Mangement_System
{
    class LOGIN
    {
        public LOGIN()// default constructor
        {

        }


        int num1 = 0;
        bool logn = false;
        //bool exist = false;
        public void login_detail()
        {
            string path = @"D:\\Project Library Mangement System\signup.txt";
                string line = "";
            start:
                FileStream login = new FileStream(path, FileMode.OpenOrCreate);
                StreamReader saad = new StreamReader(login);
                Console.WriteLine("\nEnter User Name");
                string user_name = Console.ReadLine();
                Console.WriteLine("\nEnter Password");
                string password = Console.ReadLine();
                while ((line = saad.ReadLine()) != null)
                {
                    string[] arr;
                    arr = line.Split(',');

                    if (arr[0] == user_name && arr[1] == password)
                    {
                        logn = true;
                        Console.WriteLine("\n\n\t\t\t  ||| Login Success ||| \n\n");
                        break;
                    }//if bracket
                }//while bracket
                if (logn == false)
                {
                    Console.WriteLine("Wrong User Name Or Password");
                    Console.WriteLine("Login Failed");
                    Console.WriteLine("Don't Have An Account");
                    Console.WriteLine("Press 1 for login again and 2 For Signup");
                    num1 = Convert.ToInt32(Console.ReadLine());
                    if (num1 == 1)
                    {
                        saad.Close();
                        login.Close();
                        goto start;
                    }//if bracket
                 }
        }//login detail bracket

//_________________________________________________________________________________________________________

        public void signup_detail()
        {
        input:
            bool exist = false;
        string path1 = @"D:\\Project Library Mangement System\signup.txt";
            string line1 = "";
            Console.WriteLine("\nUser Name Of Your Account");
            string usr_name = Console.ReadLine();
            Console.WriteLine("\nPassword Of Your Account");
            string pasword = Console.ReadLine();
            FileStream sigup = new FileStream(path1, FileMode.OpenOrCreate);
            StreamReader saad1 = new StreamReader(sigup);
            while ((line1 = saad1.ReadLine()) != null)
            {
                string[] arr1;
                arr1 = line1.Split(',');
                if (arr1[0] == usr_name)
                {
                    exist = true;
                    Console.WriteLine("This User Name Exist");
                    Console.WriteLine("Try Another Name");
                    break;
                }//if bracket

            }//while bracket
            saad1.Close();
            sigup.Close();
            if (exist == false)
            {
                FileStream signup = new FileStream(path1, FileMode.Append);
                StreamWriter xyz1 = new StreamWriter(signup);
                xyz1.WriteLine(usr_name + ',' + pasword);
                Console.WriteLine("Thankyou For Making An Account\nDo You Want to Login Again Press 1 ");
                xyz1.Close();
                signup.Close();
            again:
                int num2 = Convert.ToInt32(Console.ReadLine());
                if (num2 == 1)
                {
                    //BOOK b = new BOOK();
                    //b.book_detail();
                    //goto againlogin;
                }
                else
                {
                    Console.WriteLine("Wrong Input");
                    goto again; 
                }
                xyz1.Close();
                signup.Close();
            }//if bracket exist == false
            else
            {
                goto input;
            }//else bracket               
        }//signup detail bracket 
 //__________________________________ ADMIN LOGIN ______________________________________________

       public void admin_detail()
       {
        
           // bool logn = false;
           string path = @"D:\\Project Library Mangement System\admin.txt";
            string line = "";
            admn_strt:
            FileStream login = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader raza = new StreamReader(login);
            Console.WriteLine("\nAdmin User Name");
            string user_name = Console.ReadLine();
            Console.WriteLine("\nAdmin Password");
            string password = Console.ReadLine();
            while ((line = raza.ReadLine()) != null)
            {
                string[] arr;
                arr = line.Split(',');

                if (arr[0] == user_name && arr[1] == password)
                {
                    logn = true;
                    Console.WriteLine("\n\n\t\t\t ||| Login As ADMIN Success ||| \n\n");
                    break;
                }//if bracket
            }//while bracket
            if (logn == false)
            {
                Console.WriteLine("Wrong User Name Or Password");
                Console.WriteLine("Login Failed");
            admin_logn:
                Console.WriteLine("Press 3 for login again");
                num1 = Convert.ToInt32(Console.ReadLine());
                if (num1 == 3)
                {
                    raza.Close();
                    login.Close();
                    goto admn_strt;
                }//if bracket
                else
                {
                    Console.WriteLine("Wrong  Input");
                    goto admin_logn;
                }//else bracket

            }//if logn == false bracket
            else if (logn == true)
            {
                  ADMIN admn = new ADMIN();
                  admn.admin();
            }

        }// function admin_detail bracket
    }// class bracket
}// namespace bracket
 
