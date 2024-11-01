
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static public int[] PlaceLocate(string[] addressCompany)
        {
            int[] locate = { 0, 0 };
            

            if (addressCompany[0][0] == 'V')
            {
                locate[1] = Int32.Parse(addressCompany[0][1].ToString()) - 1;
                int count = 1;
                int start = 1;
                if (Int32.Parse(addressCompany[1]) % 2 == 0)
                    start++;
                for (int i = start; i != Int32.Parse(addressCompany[1]); i += 2)
                {
                    count++;
                    if (count == 2)
                    {
                        locate[0]++;
                        count = 0;
                    }

                }

            }
            else
            {
                locate[0] = Int32.Parse(addressCompany[0][1].ToString()) - 1;
                int count = 1;
                int start = 1;
                if (Int32.Parse(addressCompany[1]) % 2 == 0)
                    start++;
                for (int i = start; i != Int32.Parse(addressCompany[1]); i += 2)
                {
                    count++;
                    if (count == 2)
                    {
                        locate[1]++;
                        count = 0;
                    }

                }
                
            }
            return locate;
        }
        static public int Distance(string[] addressCustomer ,int[] locateCompany, int K)
        {
            
            int[] locateCustomer = new int[2];
            int[] currentLocate = locateCompany;
            int distance = 0;
            for (int i = 0; i < K; i++)
            {
                locateCustomer = PlaceLocate(addressCustomer[i].Split(' '));
                distance += 100 * (Math.Abs(currentLocate[0] - locateCustomer[0])) + 100 * (Math.Abs(currentLocate[1] - locateCustomer[1]));
                currentLocate = locateCustomer;
            }
            distance += 100 * (Math.Abs(currentLocate[0] - locateCompany[0])) + 100 * (Math.Abs(currentLocate[1] - locateCompany[1]));
            return distance;
        }
        static public string[] OptimiseRoute(int[] locateCompany, int K)
        {
            
            
            int[] currentLocate = locateCompany;
            string[] addressCustomer = new string[K];
            for (int i = 0; i != K; i++)
            {
                addressCustomer[i] = Console.ReadLine();
            }
            int[] locateCustomer = PlaceLocate(addressCustomer[0].Split(' '));
            int route = 0;
            string store = "";
            int minDistance = locateCompany[0] - locateCustomer[0] + locateCompany[1] - locateCustomer[1];
            for (int i = 0; i != K; i++)
            {
                locateCustomer = PlaceLocate(addressCustomer[i].Split(' '));
                for (int j = 0; j != K; j++)
                {
                    if (minDistance > (currentLocate[0] - locateCustomer[0] + currentLocate[1] - locateCustomer[1]))
                    {
                        minDistance = locateCompany[0] - locateCustomer[0] + locateCompany[1] - locateCustomer[1];
                        route = j;
                    }    
                }
                store = addressCustomer[route];
                addressCustomer[route] = addressCustomer[i];
                addressCustomer[i] = store;
                currentLocate = locateCustomer;
            }
            for (int i = 0; i != K; i++)
            {
                Console.WriteLine(addressCustomer[i]);
            }
            return addressCustomer;
        }
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            string[] addressCompany = Console.ReadLine().Split(' ');
            int[] locateCompany = PlaceLocate(addressCompany);
            byte K = Convert.ToByte(Console.ReadLine());
            string[] addressCustomer = OptimiseRoute(locateCompany, K);
            int distance = Distance(addressCustomer, locateCompany, K);
            Console.WriteLine(distance);
            Console.ReadLine();
            
        }
    }
}
