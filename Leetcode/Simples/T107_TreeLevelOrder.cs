using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T107_TreeLevelOrder
    {
        public T107_TreeLevelOrder()
        {
        }

        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            Queue<KeyValuePair<TreeNode, int>> queue = new Queue<KeyValuePair<TreeNode, int>>();    //广度优先遍历时入队队列
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();    //从队列出队的数据放在这里
            IList<IList<int>> result = new List<IList<int>>();    //存储最终结果

            if (root == null) return result;

            int level = 1;
            queue.Enqueue(new KeyValuePair<TreeNode, int>(root, level));
            while (queue.Count > 0)
            {
                KeyValuePair<TreeNode, int> pair = queue.Dequeue();
                int index = pair.Value;
                TreeNode node = pair.Key;
                if (node == null) continue;
                if (!dict.ContainsKey(index))
                {
                    List<int> sameLevelNodes = new List<int>();
                    dict.Add(index, sameLevelNodes);

                }
                dict[index].Add(node.val);

                if (node.left != null || node.right != null)
                {
                    level = index + 1;
                    if (node.left != null) queue.Enqueue(new KeyValuePair<TreeNode, int>(node.left, level));
                    if (node.right != null) queue.Enqueue(new KeyValuePair<TreeNode, int>(node.right, level));
                }
            }

            for (int i = level; i > 0; i--)
            {
                result.Add(dict[i]);
            }

            return result;
        }
    }
}
