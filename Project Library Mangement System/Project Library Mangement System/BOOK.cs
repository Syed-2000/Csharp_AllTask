using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Mangement_System
{
    class BOOK
    {
        int code_len = 0;  //find total code
        int book_len = 0;  //find total book
        int address_len = 0;//find total address
        string[] code = new string[100];
        string[] BookName = new string[100];
        string[] src = new string[100];

//_________________________________________________________________________________________________________

        public void book_detail()
        {
            string path2 = @"D:\\Project Library Mangement System\Book.txt";
            FileStream bok = new FileStream(path2, FileMode.Open, FileAccess.Read);
            StreamReader book = new StreamReader(bok);
            string line2 = "";
            while ((line2 = book.ReadLine()) != null)
            {
                string[] ShelfRowColumn;
                ShelfRowColumn = line2.Split(',');
                int result = int.Parse(ShelfRowColumn[5]); //to check we have a book quantity avaliable
                if (result > 0)
                {
                    code[code_len] = ShelfRowColumn[0];
                    code_len++;
                    BookName[book_len] = ShelfRowColumn[1];
                    book_len++;
                    src[address_len] = ShelfRowColumn[2] + "," + ShelfRowColumn[3] + "," + ShelfRowColumn[4] + "," + ShelfRowColumn[5];
                    address_len++;
                }

             }//while bracket

            // print code no & books
            for (int i = 0; i < code_len; i++)
            {
                Console.Write(code[i] + "\t");
                Console.Write(BookName[i] + "\t");
                Console.WriteLine();
            }

            book.Close();
            bok.Close();

            string[] code1 = new string[100];
            Console.Write("\n\nEnter Book Code No You Want To Read : ");
            String BookCodeNo = Console.ReadLine();
            int INDE = Array.IndexOf(code1, BookCodeNo);
            //Console.WriteLine(INDE);
            Console.WriteLine("\n\n\t |||Thankyou For Visiting Our Library Amangement System |||\n\n");
            string[][] save_value = new string[100][];
            string path3 = @"D:\\Project Library Mangement System\Book.txt";
            FileStream read_bok = new FileStream(path3, FileMode.Open, FileAccess.Read);
            StreamReader read_book = new StreamReader(read_bok);
            string line3 = "";
            int j = 0;
            int value = 0;
            while ((line3 = read_book.ReadLine()) != null)
            {
                string[] SaveValue;
                SaveValue = line3.Split(',');

                if (SaveValue[j] == BookCodeNo)
                {
                    int result1 = 1;
                    value = int.Parse(SaveValue[5]) - result1;
                }
                save_value[0] = SaveValue;                
            }//while bracket
            
            read_book.Close();
            read_bok.Close();

//______________________________________________________________________________________________________  
 
            // substract vaule in file
//______________________________________________________________________________________________________   

            string path4 = @"D:\\Project Library Mangement System\Book.txt";
            FileStream chng_qnty = new FileStream(path4, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader change_quantity = new StreamReader(chng_qnty);
            for (int i = 0; i < code_len; i++)
            {
                if (BookCodeNo == code[i])
                {
                    int indx = Array.IndexOf(code, BookCodeNo);
                    string[] splt_value;
                    splt_value = src[indx].Split(',');
                    splt_value[3] =  (int.Parse(splt_value[3]) - 1).ToString();
                    src[indx] = splt_value[0] + "," + splt_value[1] + "," + splt_value[2] + "," + splt_value[3];
                    change_quantity.Close();
                    chng_qnty.Close();
                }  
            }

        //_____________________________________________________________________________
        //overwrite Value
        //_____________________________________________________________________________


            Console.WriteLine();
            FileStream overwrite = new FileStream(path4, FileMode.Open ,FileAccess.Write);
            StreamWriter over_write = new StreamWriter(overwrite);
            for (int i = 0; i < code_len; i++)
            {
                over_write.WriteLine(code[i] + "," + BookName[i] + "," + src[i]);    
            }

            over_write.Close();
            overwrite.Close();
        }
    }
}