using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CafeManagementSystem
{
    class AdminPage:Program
    {
        public string path  = Program.path;
        public string path2 = Program.path2;
        public string path3 = Program.path3;
        public string path4 = Program.path4;
        public AdminPage()
        {
            Console.WriteLine("WELCOME TO ADMIN PAGE");
        }
        //public void itemsBreaker(out int myVar)
        //{
        //    string pa = @"C:\Users\osama\Desktop\Csharp\ManagementSystemsOnConsole\CafeManagementSystem\CafeManagementSystem\TxtFiles\Items.txt";
        //    string[] all_lines = File.ReadAllLines(pa, Encoding.UTF8);
        //    int count = 0;
        //    foreach (string item in all_lines)
        //    {
        //        count++;
        //    }
        //   // Console.WriteLine(count);
        //    string[][] arr = new string[count][];

        //    for (int i = 0; i < count; i++)
        //    {
        //        arr[i] = all_lines[i].Split(',');
        //    }
        //    // Console.WriteLine(arr[1][0]);
        //    //for (int i = 0; i < count; i++)
        //    //{
        //    //    for (int j = 0; j <= count;  j++)
        //    //    {
        //    //        Console.WriteLine(arr[i][j]);
        //    //    }
        //    //    Console.WriteLine();
        //    //}
        //    //Console.WriteLine(arr[count-1][0]);
        //    myVar = Convert.ToInt32(arr[count-1][0]);
        //    //Console.WriteLine(myVar);
        //}
        public void itemWriter(int myVar, int no_of_items, string[] item_name, int[] quantity_Of_Items, int[] item_price)
        {

            FileStream items = new FileStream(path, FileMode.Append);
            StreamWriter item = new StreamWriter(items);
            Console.WriteLine("\nvar:{0}", myVar);
            int aikVar = myVar + no_of_items;

            //Written on file
            Console.WriteLine("file written like this");
            for (int i = (myVar + 1); i <= aikVar; i++)
            {
                item.WriteLine(i + "," + item_name[i- (myVar + 1)] + "," + item_price[i- (myVar + 1)] + "," + quantity_Of_Items[i - (myVar + 1)]);
                Console.WriteLine(i + "," + item_name[i - (myVar + 1)] + "," + +item_price[i - (myVar + 1)] + "," + quantity_Of_Items[i - (myVar + 1)]);
            }
            item.Close();
            items.Close();

        }
        //------------------------------------------------------------------------------------------------------
        public void addItems()
        {
            int no_of_items;

            FileStream readIndex = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader red = new StreamReader(readIndex);
            string[] all_lines = File.ReadAllLines(path, Encoding.UTF8);
            int count = 0;
            foreach (string ite in all_lines)
            {
                count++;

            }

            string[][] arr = new string[count][];

            for (int i = 0; i < count; i++)
            {
                arr[i] = all_lines[i].Split(',');
            }

            // --------------------------------------------------------------------------------------------------
            Console.WriteLine("\nHow many Items you want to add");
            no_of_items = Convert.ToInt32(Console.ReadLine());
            int[] quantity_Of_Items = new int[no_of_items];
            int[] item_price = new int[no_of_items];
            string[] item_name = new string[no_of_items];


            // --------------------------------------------------------------------------------------------------
            Console.WriteLine("\nWrite names of items\n");
            for (int i = 0; i < no_of_items; i++)
            {
                item_name[i] = Console.ReadLine();
                if (item_name[i] == arr[i][1])
                {
                    Console.WriteLine("Item {0} Already Exsist",item_name[i]);
                }

            }

            // --------------------------------------------------------------------------------------------------
            Console.WriteLine("\nNow write the quantites\n");
            for (int i = 0; i < no_of_items; i++)
            {
                Console.Write(item_name[i] + "\t");
                quantity_Of_Items[i] = Convert.ToInt32(Console.ReadLine());
            }

            // --------------------------------------------------------------------------------------------------
            Console.WriteLine("\nNow write the price of individual");
            for (int i = 0; i < no_of_items; i++)
            {
                Console.Write(item_name[i] + "\t" + quantity_Of_Items[i] + "\t");
                item_price[i] = Convert.ToInt32(Console.ReadLine());
            }

            // --------------------------------------------------------------------------------------------------
            Console.WriteLine("\nItems are\n");
            Console.WriteLine("Items \t Quantity \t Price \t Total_Price");
            for (int i = 0; i < no_of_items; i++)
            {
                Console.WriteLine(item_name[i] + "\t\t" + quantity_Of_Items[i] + "\t" + item_price[i] + "\t" + quantity_Of_Items[i] * item_price[i]);
            }

            // --------------------------------------------------------------------------------------------------
            int myVar;
           
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine(arr[i][j]);
                }
                Console.WriteLine();
            }
            if (count==0)
            {
                myVar = 0;
                Console.WriteLine("Nothing is present in the file");
                
            }
            else
            {
                string vr = arr[count - 1][0];
                Console.WriteLine(arr[count - 1][0]);
                myVar = Int32.Parse(vr);
            }
            
            red.Close();
            readIndex.Close();

            itemWriter(myVar, no_of_items, item_name, quantity_Of_Items, item_price);
           

        }

        public void delItems()
        {
            Console.WriteLine("Delete Items");
            Console.WriteLine();
            Console.Clear();
            string[] lines = File.ReadAllLines(path, Encoding.UTF8);
            Console.WriteLine("Items are:\n");
            int incrementer = 0;
            Console.WriteLine();
            foreach (string line in lines)
            {
                incrementer++;
            }
            string[][] arr = new string[incrementer][];
            for (int i = 0; i < incrementer; i++)
            {
                arr[i] = lines[i].Split(',');
            }
            if (incrementer == 0)
            {
                Console.WriteLine("\nThere are no items to display from the file\n");
                Console.WriteLine("If you want to write items write admin secret password to add");

                string pass = passwordHider();
                if (pass == "adminPass123")
                {
                    forAdmin();
                }

            }
            else
            {
                Console.WriteLine("Serial.No\tItems\t\t\tPrice\t\tQuantityLeft\n");
                for (int i = 0; i < incrementer; i++)
                {
                    Console.WriteLine(arr[i][0] + "\t\t" + arr[i][1] + "\t\t" + arr[i][2] + "\t\t" + arr[i][3]);
                }



                List<string> list = new List<string>(lines);

                int code;
                //do
                //{
                Console.WriteLine("Enter the code you want to delete and 0000 to terminate");
                code = Convert.ToInt32(Console.ReadLine());
                code = code - 1;
                list.RemoveAt(code);


                Console.WriteLine("After deleting");
                for (int i = 0; i < incrementer - 1; i++)
                {
                    Console.WriteLine(list[i]);
                }
                Console.WriteLine();
                Console.WriteLine("You delete the item {0} named as {1} from the file", arr[code][0], arr[code][1]);
                // }
                //while (code != 0000);
                //Console.WriteLine(arr[code]);
                FileStream fileT = new FileStream(path, FileMode.Truncate);
                fileT.Close();
                FileStream fle = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter writer = new StreamWriter(fle);
                //writer.WriteLine(arr[code]);
                for (int i = 0; i < incrementer - 1; i++)
                {
                    writer.WriteLine(list[i]);
                }
                writer.Close();
                fle.Close();
            }

         
        }
        public void soldItems()
        {
            Console.Clear();
            string[] print = File.ReadAllLines(path2, Encoding.UTF8);
            int count = 0;
            foreach (string item in print)
            {
                Console.WriteLine(item);
                count++;
            }
            if (count==0)
            {
                Console.WriteLine("Nothing had been sold yet");
            }

        }
        public void searchItems()
        {
            Console.Clear();
        correct:
            FileStream fles = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader read = new StreamReader(fles);
            string[] all_lines = File.ReadAllLines(path, Encoding.UTF8);
            int count = 0;
            foreach (string item in all_lines)
            {
                Console.WriteLine(item);
                count++;
            }

            read.Close();
            fles.Close();
            if (count == 0)
            {
                Console.WriteLine("Nothing to search");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("How do you want to search it?");
                Console.WriteLine("1-By name\n2-By ID number\n3-By Date");
                int search;
                search = Convert.ToInt32(Console.ReadLine());
                if (search == 1)
                {
                    searchByName();
                }
                else if (search == 2)
                {
                    searchByID();
                }
                else if (search == 3)
                {
                    searchByDate();
                }
                else
                {
                    Console.WriteLine("You mention wrong number");
                    Console.WriteLine();
                    Console.WriteLine("Please write correct number");
                    goto correct;
                }
            }
        }
        public void searchByName()
        {
           FileStream flesBN = new FileStream(path, FileMode.Open, FileAccess.Read);
           StreamReader readBN = new StreamReader(flesBN);
           string[] all_linesBN = File.ReadAllLines(path, Encoding.UTF8);

            int count = 0;
            foreach (string itemBN in all_linesBN)
            {
                count++;
            }
            string[][] aikString = new string[count][];
            for (int i = 0; i < count; i++)
            {
                aikString[i] = all_linesBN[i].Split(',');
            }
            string names;
            Console.WriteLine("\nEnter Names please and write word 'stop' to end \n");
            names = Console.ReadLine();
            for (int i = 0; i < count; i++)
            {
                if (names == aikString[i][1])
                {
                    Console.WriteLine("Your item is:{0}\nID no of that item is: {1}\nPrice of that item is: {2}\nQuantity Reamainings are: {3}\n",names, aikString[i][0],aikString[i][2],aikString[i][3]);
                    break;
                }
            }
            
            while(names!="stop")
            {
                Console.WriteLine("\nEnter Names please and write word 'stop' to end \n");
                names = Console.ReadLine();
                for (int i = 0; i < count; i++)
                {
                    if (names == aikString[i][1])
                    {
                        Console.WriteLine("Your item is:{0}\nID no of that item is: {1}\nPrice of that item is: {2}\nQuantity Reamainings are: {3}\n", names, aikString[i][0], aikString[i][2], aikString[i][3]);
                        break;
                    }
                }

            }
            readBN.Close();
            flesBN.Close();
        }
        public void searchByID()
        {
            FileStream flesBN = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader readBN = new StreamReader(flesBN);
            string[] all_linesBN = File.ReadAllLines(path, Encoding.UTF8);
            int rand = Program.GenerateRandomNo();

            int count = 0;
            foreach (string itemBN in all_linesBN)
            {
                count++;
            }
            string[][] aikString = new string[count][];
            for (int i = 0; i < count; i++)
            {
                aikString[i] = all_linesBN[i].Split(',');
            }
            int num;
            Console.WriteLine("\nEnter ID number please and write {0} to end \n",rand);
            num = Convert.ToInt32(Console.ReadLine());
            num = num - 1;
            for (int i = 0; i < count; i++)
            {
                if (num == int.Parse(aikString[i][0]))
                {
                    Console.WriteLine("ID no of that item is: {0}\nYour item is:{1}\nPrice of that item is: {2}\nQuantity Reamainings are: {3}\n", num+1 , aikString[num][1], aikString[i][2], aikString[i][3]);
                    break;
                }
            }

            while (num != rand )
            {
                Console.WriteLine("\nEnter Names please and write {0} to end \n",rand);
                num = Convert.ToInt32(Console.ReadLine());
                num = num - 1;
                for (int i = 0; i < count; i++)
                {
                    if (num == int.Parse(aikString[i][0]))
                    {
                        Console.WriteLine("ID no of that item is: {0}\nYour item is:{1}\nPrice of that item is: {2}\nQuantity Reamainings are: {3}\n", num+1, aikString[num][1], aikString[i][2], aikString[i][3]);
                        break;
                    }
                }

            }
            readBN.Close();
            flesBN.Close();
        }
        public void searchByDate()
        {

            string day, month, year;
            Console.Write("Enter day: \t");
            day = Console.ReadLine();
            Console.Write("Enter month: \t");
            month = Console.ReadLine();
            Console.Write("Enter year: \t");
            year = Console.ReadLine();
            string date = day + "/" + month + "/" + year;
            //Console.WriteLine(date); 
            string[] line = File.ReadAllLines(path3, Encoding.UTF8);
            int c = 0;
            foreach (string item in line)
            {
                c++;
            }
            int index = 0;
            int index2 = 0;
            int x;

            for (int i = 0; i < c; i++)
            {
                if (line[i] == date)
                {
                    index = i;
                    //Console.WriteLine("found at: {0}", index);
                    break;
                }
            }

            while (line[index] != "DateTime")
            {
                //Console.WriteLine("found at: {0}", index);
                Console.WriteLine(line[index]);
                index++;

            }
            

        }
        public void updateItems()
        {
            string[] complete_file = File.ReadAllLines(path, Encoding.UTF8);
            int counter = 0;
            foreach (string item in complete_file)
            {
                counter++;
            }

            string[][] array2d = new string[counter][];
            for (int i = 0; i < counter; i++)
            {
                array2d[i] = complete_file[i].Split(',');
            }
            if (counter == 0)
            {
                Console.WriteLine("\nThere are no items to display from the file\n");
                Console.WriteLine("If you want to write items write admin secret password to add");

                string pass = passwordHider();
                if (pass == "adminPass123")
                {
                    forAdmin();
                }

            }
            else
            {
                for (int i = 0; i < counter; i++)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", array2d[i][0], array2d[i][1], array2d[i][2], array2d[i][3]);
                }
                FileStream file = new FileStream(path, FileMode.Truncate);
                file.Close();
                int option;
                Console.WriteLine("Which item you want to updated?\n1\tPrice\n2\tQuantity");

                option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        updatePrice(counter, path, array2d);
                        break;
                    case 2:
                        updateQuantity(counter, path, array2d);
                        break;
                    default:
                        break;
                }
            }
        }
        public void updatePrice(int counter, string path, string[][] array2d)
        {
            int index, price;
            Console.WriteLine("Enter index from above items");
            index = Convert.ToInt32(Console.ReadLine());
            index = index - 1;

            Console.WriteLine();
            Console.WriteLine("Now enter the price you want to update");
            price = Convert.ToInt32(Console.ReadLine());

            array2d[index][2] = price.ToString();

            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Write);
            StreamWriter fileWrite = new StreamWriter(file);

            for (int i = 0; i < counter; i++)
            {
                fileWrite.WriteLine("{0},{1},{2},{3}", array2d[i][0], array2d[i][1], array2d[i][2], array2d[i][3]);
                Console.WriteLine("{0},{1},{2},{3}", array2d[i][0], array2d[i][1], array2d[i][2], array2d[i][3]);
            }
            fileWrite.Close();
            file.Close();


        }
        public void updateQuantity(int counter, string path, string[][] array2d)
        {
            int index, quant;
            Console.WriteLine("Enter index from above items");
            index = Convert.ToInt32(Console.ReadLine());
            index = index - 1;

            Console.WriteLine();
            Console.WriteLine("Now enter the quantity you want to update");
            quant = Convert.ToInt32(Console.ReadLine());

            array2d[index][3] = quant.ToString();

            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Write);
            StreamWriter fileWrite = new StreamWriter(file);

            for (int i = 0; i < counter; i++)
            {
                fileWrite.WriteLine("{0},{1},{2},{3}", array2d[i][0], array2d[i][1], array2d[i][2], array2d[i][3]);
                Console.WriteLine("{0},{1},{2},{3}", array2d[i][0], array2d[i][1], array2d[i][2], array2d[i][3]);
            }
            fileWrite.Close();
            file.Close();

        }
       
        
    }   
         
    

           





    }



