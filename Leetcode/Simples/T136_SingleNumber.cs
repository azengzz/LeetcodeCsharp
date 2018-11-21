using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T136_SingleNumber
    {
        public T136_SingleNumber()
        {
        }

        //T136 非空整数数组里，除了某一个数字，其他整数均出现2遍。找出这个只出现一次的整数
        public int GetSingleNumber(int[] nums)
        {
            //由于确定是数组中除了某个数之外，其它数都是有两个的。利用异或“相同为0”的特点，
            //将数组中所有值异或计算，得到的就是那个只出现一次的数
            int single = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                single ^= nums[i];
            }
            return single;
        }
        //其他的思路：1，先排序，然后再找；2，使用字典，数组下标作为Key，数组成员为Value，目标数字在字典中只有唯一的Key
    }
}
