using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Treesort
    {
        public static void Run(int[] array)
        {
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }

            treeNode.Transform();
        }

        public class TreeNode
        {
            public TreeNode(int data)
            {
                Data = data;
            }
            
            public int Data { get; set; }
            public TreeNode Left { get; set; } 
            public TreeNode Right { get; set; }
            
            public void Insert(TreeNode node)
            {
                if (node.Data < Data)
                {
                    if (Left == null)
                    {
                        Left = node;
                    }
                    else
                    {
                        Left.Insert(node);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = node;
                    }
                    else
                    {
                        Right.Insert(node);
                    }
                }
            }
            
            public int[] Transform(List<int> elements = null)
            {
                if (elements == null)
                {
                    elements = new List<int>();
                }

                if (Left != null)
                {
                    Left.Transform(elements);
                }

                elements.Add(Data);

                if (Right != null)
                {
                    Right.Transform(elements);
                }

                return elements.ToArray();
            }
        }
    }
}
