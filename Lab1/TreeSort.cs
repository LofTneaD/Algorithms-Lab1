using System;
using System.Collections.Generic;

namespace Lab1
{
    internal class Treesort
    {
        public static void Run(int[] array)
        {
            if (array == null || array.Length == 0)
                return;

            // Создаем корень дерева
            var treeNode = new TreeNode(array[0]);
            for (int i = 1; i < array.Length; i++)
            {
                treeNode.Insert(new TreeNode(array[i]));
            }
            var sortedArray = treeNode.Transform();
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

            // Метод вставки узла в дерево
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

            // Метод преобразования дерева в отсортированный массив
            public int[] Transform(List<int> elements = null)
            {
                if (elements == null)
                {
                    elements = new List<int>();
                }

                // Рекурсивно добавляем элементы левого поддерева
                if (Left != null)
                {
                    Left.Transform(elements);
                }

                // Добавляем текущий узел
                elements.Add(Data);

                // Рекурсивно добавляем элементы правого поддерева
                if (Right != null)
                {
                    Right.Transform(elements);
                }

                // Возвращаем отсортированный массив
                return elements.ToArray();
            }
        }
    }
}
