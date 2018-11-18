using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T118_PascalTraingle
    {
        public T118_PascalTraingle()
        {
        }

        //T118 生成杨辉三角的前N行
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> pascalTraingle = new List<IList<int>>();
            List<List<int>> firstTwoRows = new List<List<int>>() { new List<int>() { 1 }, new List<int>() { 1, 1 } };
            
            int preSetRows = numRows > 2 ? 2 : numRows;

            for (int i = 0; i < preSetRows; i++)
            {
                pascalTraingle.Add(firstTwoRows[i]);
            }
            if (numRows > 2)
            {
                for (int i = 2; i < numRows; i++)
                {
                    IList<int> newRow = new List<int>() { 1, 1 };
                    IList<int> lastRow = pascalTraingle[i - 1];

                    for (int j = 0; j < lastRow.Count - 1; j++)
                    {
                        newRow.Insert(j + 1, lastRow[j] + lastRow[j + 1]);
                    }
                    pascalTraingle.Add(newRow);
                }
            }
            return pascalTraingle;
        }

        //T119 生成杨辉三角的第N行（从0行开始算）
        public IList<int> GetRow(int rowIndex)
        {
            IList<int> pascalTraingle_N = null;

            if (rowIndex == 0) pascalTraingle_N = new List<int> { 1 };
            else if (rowIndex == 1) pascalTraingle_N = new List<int> { 1, 1 };
            else
            {
                pascalTraingle_N = new List<int> { 1, 1 };
                for (int i = 2; i <= rowIndex; i++)
                {
                    IList<int> newRow = new List<int>() { 1, 1 };
                    for (int j = 0; j < pascalTraingle_N.Count - 1; j++)
                    {
                        newRow.Insert(j + 1, pascalTraingle_N[j] + pascalTraingle_N[j + 1]);
                    }
                    pascalTraingle_N = newRow;
                }
            }
            return pascalTraingle_N;
        }
    }
}
