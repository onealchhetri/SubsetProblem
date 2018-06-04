using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubsetProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> SArray = new List<int>() { 9,5,6,8,2};
            int k = 19;

            

            SArray.Sort();
            SArray.Reverse();


            List<int[]> SubsetList = new List<int[]>();
            
            if(SArray[SArray.Count -1] == k)
            {
                SubsetList.Add(new int[] { SArray[SArray.Count - 1] });
            }


            for (int i = 0; i < SArray.Count -1; i++)
            {
                Stack<int> temp = new Stack<int>();
                int sum = 0;               
                if (SArray[i] < k)
                {
                    temp.Push(SArray[i]);
                    sum = temp.Peek();
                    for (int j = i + 1; j < SArray.Count; j++)
                    {
                        sum += SArray[j];
                        temp.Push(SArray[j]);
                        if(sum > k)
                        {
                            sum -= temp.Pop();
                        }
                        else if(sum == k)
                        {
                            SubsetList.Add(temp.ToArray());
                            temp = new Stack<int>();
                            sum = 0;
                        }
                        else
                        {
                            continue;
                        }


                    }
                }
                else if(SArray[i] == k ) 
                {
                    List<int> temp2 = new List<int>();
                    temp2.Add(SArray[i]);
                    SubsetList.Add(temp2.ToArray());
                }
            
               
            }

            if (SubsetList.Count == 0)
                Console.WriteLine("null");
            else
            {
                //Console.WriteLine(SubsetList.Count.ToString());
                foreach( int a in SubsetList[0])
                    Console.WriteLine(a);

                Console.WriteLine("----------------");
            }


            
            Console.ReadLine();


        }


        
    }
}
