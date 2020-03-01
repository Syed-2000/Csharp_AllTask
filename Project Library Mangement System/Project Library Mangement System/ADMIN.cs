using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Library_Mangement_System
{
    class ADMIN
    {

        public ADMIN()
        {
                
        }
//_________________________________________________________________________________________________________

        public void admin()
        {
            Console.WriteLine();
            Console.WriteLine("1 for update item\n2 for delete item\n3 for new item");
            int choise = Convert.ToInt32(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Inventry updateitems = new Inventry();
                    updateitems.show_item();
                    updateitems.update();
                    break;
                case 2:
                        Inventry deleteitem = new Inventry();
                        deleteitem.show_item();
                        Console.WriteLine("Enter Code No to delete");
                        string delete_codeno = Console.ReadLine();
                        deleteitem.delete(delete_codeno);
                    break;
                case 3:
                    Inventry newitem = new Inventry();
                    newitem.add_item();
                    break;

                default:
                    break;
            }
        }
    }
}

