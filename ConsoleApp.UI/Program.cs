using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

             var categories= categoryManager.GetAll();
            foreach (var category in categories)
            {
                Console.WriteLine(category.Name);
                Console.WriteLine(category.Description);
            }

            Console.ReadLine();
        }
    }
}
