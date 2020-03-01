using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Mangement_System
{
    class Inventry
    {
        string[] code = new string[100];
        string[] BookName = new string[100];
        string[] src = new string[100];
        
        public Inventry()
        {

        }
        public void add_item()
        {
        shelf:
        input:
            string[] arr = null;
            int count = 0;
            string path = @"D:\\Project Library Mangement System\Book.txt";
            //string temp_path = @"D:\\Project Library Mangement System\temp.txt";       
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            Console.Write("Enter Book Code No : ");
            code[0] = Console.ReadLine();
            Console.Write("Enter Book Name : ");
            BookName[1] = Console.ReadLine();
            Console.Write("Enter Shelf No : ");
            src[2] = Console.ReadLine();
            Console.Write("Enter Row No : ");
            src[3] = Console.ReadLine();
            Console.Write("Enter Column No : ");
            src[4] = Console.ReadLine();
            Console.Write("Enter Quantity : ");
            src[5] = Console.ReadLine();
            
            string line12 = "";
            while ((line12 = sr.ReadLine()) != null)
            {
               // string[] arr;
                arr = line12.Split(',');
                //Console.WriteLine(arr[2] + "," + arr[3] + "," + arr[4]);
                //Console.WriteLine(src[2] + "," + src[3] + "," + src[4]);
                count++;
            }
            sr.Close();
            fs.Close();
             
            FileStream updateitem = new FileStream(path, FileMode.Append);
            StreamWriter update_item = new StreamWriter(updateitem);
            for (int i = 0; i < count; i++)
			{
                if (code [0] == arr[0])
	            {
                    Console.WriteLine("Wrong Code No");
                    goto input;
	            }

			}
            for (int i = 0; i < count ; i++)
            {
                if ( (arr[2] + "," + arr[3] + "," + arr[4]) == (src[2] + "," + src[3] + "," + src[4]) )
                {
                    Console.WriteLine("This Column Has Being Filled\nTry Again");
                   
                    update_item.Close();
                    updateitem.Close();
                    goto shelf;
                }
                else
                {
                    line12 = (code[0] + "," + BookName[1] + "," + src[2] + "," + src[3] + "," + src[4] + "," + src[5]);
                    break;
                }
            } // for bracket
            update_item.WriteLine(line12);
 
            update_item.Close();
            updateitem.Close();


            //string s = File.ReadAllText(temp_path);
            //File.WriteAllText(path, s);
            //File.Delete(temp_path);
        }


        public void show_item()
        {
            string actual_path = @"D:\\Project Library Mangement System\Book.txt";
            FileStream fs = new FileStream(actual_path, FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(fs);
            string line;
            Console.WriteLine("Code No   Book Name \tShelf \t\tRow \t Column \t Quantity ");
            while ((line = sr.ReadLine()) != null)
            {
                string[] arr;
                arr = line.Split(',');
                Console.WriteLine(arr[0] + "\t" + arr[1] + "\t\t" + arr[2] + "\t\t" + arr[3] + "\t\t" + arr[4] + "\t\t" + arr[5]);
            }
            sr.Close();
            fs.Close();

        }

        public void delete(string code)
        {
            string actual_path = @"D:\\Project Library Mangement System\Book.txt";
            string temp_path = @"D:\\Project Library Mangement System\temp.txt";
            FileStream actpth = new FileStream(actual_path, FileMode.OpenOrCreate); 
            StreamReader actualpath = new StreamReader(actpth);
            FileStream delte = new FileStream(temp_path, FileMode.Create); 
            StreamWriter delete = new StreamWriter(delte); 
            string line;

            while ((line = actualpath.ReadLine()) != null)
            {
                string[] arr;
                arr = line.Split(',');
                if (arr[0] != code)
                {
                    delete.WriteLine(line);
                }
            }

            delete.Close();
            delte.Close();
            actualpath.Close();
            actpth.Close();

            string s = File.ReadAllText(temp_path);
            File.WriteAllText(actual_path, s);
            File.Delete(temp_path);

        }


        
        public void update()
        {
            Console.WriteLine();
            Console.WriteLine("Enter the Code No you want to update");
            string ID = Console.ReadLine();
            Console.WriteLine("1 for Update Address\n2 for Update Quantity ");
            int opt = Convert.ToInt32(Console.ReadLine());
            switch (opt)
            {
                case 1:// price
                    Console.Write("Enter new Shelf : ");
                    string shelf = Console.ReadLine();
                    Console.Write("Enter new Row No : ");
                    string row = Console.ReadLine();
                    Console.Write("Enter new Column No : ");
                    string column = Console.ReadLine();
                    string actual_path = @"D:\\Project Library Mangement System\Book.txt";
                    string temp_path = @"D:\\Project Library Mangement System\temp.txt";
                    FileStream fs = new FileStream(actual_path, FileMode.OpenOrCreate);
                    StreamReader sr = new StreamReader(fs);
                    FileStream fa = new FileStream(temp_path, FileMode.Create);
                    StreamWriter sw = new StreamWriter(fa);
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] arr;
                        arr = line.Split(',');
                        if (arr[0] != ID)
                        {
                            sw.WriteLine(line);
                        }
                        else if (arr[0] == ID)
                        {
                            arr[2] = shelf;
                            arr[3] = row;
                            arr[4] = column;
                            line = arr[0] + "," + arr[1] + "," + arr[2] + "," + arr[3]+ "," + arr[4]+ "," + arr[5];
                            sw.WriteLine(line);   
                        }

                    }

                    sw.Close();
                    fa.Close();
                    sr.Close();
                    fs.Close();

                    string s = File.ReadAllText(temp_path);
                    File.WriteAllText(actual_path, s);
                    File.Delete(temp_path);
                    Console.WriteLine("\n\n\nAddress Updated\n\n");
                    show_item();
                    break;

                case 2: // quantity

                    Console.Write("Enter new Quantity : ");
                    string quantity = Console.ReadLine();
                    string quantity_path = @"D:\\Project Library Mangement System\Book.txt";
                    string qunty_path = @"D:\\Project Library Mangement System\temp.txt";
                    FileStream ffs = new FileStream(quantity_path, FileMode.OpenOrCreate);
                    StreamReader ssr = new StreamReader(ffs);
                    FileStream faa = new FileStream(qunty_path, FileMode.Create);
                    StreamWriter ssw = new StreamWriter(faa);
                    string line1;

                    while ((line1 = ssr.ReadLine()) != null)
                    {
                        string[] arr;
                        arr = line1.Split(',');
                        if (arr[0] != ID)
                        {
                            ssw.WriteLine(line1);
                        }
                        else if (arr[0] == ID)
                        {
                            arr[5] = quantity;
                            line1 = arr[0] + "," + arr[1] + "," + arr[2] + "," + arr[3]+ "," + arr[4]+ "," + arr[5];
                            ssw.WriteLine(line1);
                        }

                    }

                    ssw.Close();
                    faa.Close();
                    ssr.Close();
                    ffs.Close();

                    string upqt = File.ReadAllText(qunty_path);
                    File.WriteAllText(quantity_path, upqt);
                    File.Delete(qunty_path);
                    Console.WriteLine("\n\n\nQuantity Updated\n\n");
                    break;
                

                default:
                    Console.WriteLine("Default");
                    break;
            }

        }

    }
}
