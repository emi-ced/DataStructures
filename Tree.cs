using System.Numerics;

namespace DataStructures
{
    public class BinarySearchTreeNode
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public BinarySearchTreeNode Left { get; set; }
        public BinarySearchTreeNode Right { get; set; }

        public BinarySearchTreeNode(int key, int value)
        {
            Key = key;
            Value = value;
        }
    }

    // Time complexity: O(n) - Theta(log n)
    // Space complexity: O(n) - Theta(log n)
    public class BinarySearchTree
    {
        private BinarySearchTreeNode Root { get; set; }

        public BinarySearchTree() {}

        public void Insert(int key, int val)
        {
            Root = InsertInternal(Root, key, val);
        }

        private BinarySearchTreeNode InsertInternal(BinarySearchTreeNode node, int key, int value)
        {
            if (node == null || node.Key == key)
                return new BinarySearchTreeNode(key, value);

            if (key > node.Key)
                node.Right = InsertInternal(node.Right, key, value);
            else
                node.Left = InsertInternal(node.Left, key, value);

            return node;
        }

        public int Get(int key)
        {
            return GetInternal(Root, key);
        }

        private int GetInternal(BinarySearchTreeNode node, int key)
        {
            if (node == null)
                return -1;

            if (key > node.Key)
                return GetInternal(node.Right, key);
            else if (key < node.Key)
                return GetInternal(node.Left, key);
            else
                return node.Value;
        }

        public int GetMin()
        {
            BinarySearchTreeNode currentNode = Root;

            while (currentNode != null && currentNode.Left != null)
                currentNode = currentNode.Left;

            return currentNode?.Value ?? - 1;
        }

        public int GetMax()
        {
            BinarySearchTreeNode currentNode = Root;

            while (currentNode != null && currentNode.Right != null)
                currentNode = currentNode.Right;

            return currentNode?.Value ?? - 1;
        }

        public void Remove(int key)
        {
            Root = RemoveInternal(Root, key);
        }

        private BinarySearchTreeNode RemoveInternal(BinarySearchTreeNode node, int key)
        {
            if (node == null)
                return null;

            if (key > node.Key)
                node.Right = RemoveInternal(node.Right, key);
            else if (key < node.Key)
                node.Left = RemoveInternal(node.Left, key);
            else
            {
                if (node.Left == null)
                    return node.Right;
                else if (node.Right == null)
                    return node.Left;
                else
                {
                    var minNode = FindMin(node.Right);

                    node.Key = minNode.Key;
                    node.Value = minNode.Value;
                    node.Right = RemoveInternal(node.Right, node.Key);
                }
            }

            return node;
        }

        private BinarySearchTreeNode FindMin(BinarySearchTreeNode node)
        {
            while (node?.Left != null)
                node = node.Left;

            return node;
        }

        public List<int> GetInorderKeys()
        {
            var keys = new List<int>();
            GetInOrderKeyInternal(keys, Root);

            return keys;
        }

        private List<int> GetInOrderKeyInternal(List<int> keys, BinarySearchTreeNode node)
        {
            if (node == null)
                return keys;

            GetInOrderKeyInternal(keys, node.Left);
            keys.Add(node.Key);
            GetInOrderKeyInternal(keys, node.Right);

            return keys;
        }
    }

    public class SegmentNode
    {
        public int Value { get; set; }

        public int LeftIndex { get; set; }
        public int RightIndex { get; set; }

        public SegmentNode LeftNode { get; set; }
        public SegmentNode RightNode { get; set; }

        public SegmentNode(int value, int leftIndex, int rightIndex)
        {
            Value = value;
            LeftIndex = leftIndex;
            RightIndex = rightIndex;
        }
    }
    
    public class SegmentTree
    {

        private SegmentNode _segmentNodeRoot;

        public SegmentTree(int[] nums)
        {
            _segmentNodeRoot = GenerateSegmentTree(nums, 0, nums.Length - 1);
        }

            
        // Time complexity: O(log n)
        // Space complexity: O(log n)
        public void Update(int index, int val)
        {
            UpdateInternal(index, val, _segmentNodeRoot);
        }

        private void UpdateInternal(int targetIndex, int newValue, SegmentNode currentNode)
        {
            if (currentNode.LeftIndex == currentNode.RightIndex)
            {
                currentNode.Value = newValue;
                return;
            }

            int midIndex = currentNode.LeftIndex + ((currentNode.RightIndex - currentNode.LeftIndex) / 2);

            if (targetIndex <= midIndex)
                UpdateInternal(targetIndex, newValue, currentNode.LeftNode);
            else
                UpdateInternal(targetIndex, newValue, currentNode.RightNode);

            currentNode.Value = currentNode.LeftNode?.Value + currentNode.RightNode?.Value ?? 0;
        }

        // Time complexity: O(log n)
        // Space complexity: O(log n)        
        public int Query(int L, int R)
        {
            Console.WriteLine("Start " + L + " " + R);
            return QueryInternal(L, R, _segmentNodeRoot);
        }

        private int QueryInternal(int leftIndex, int rightIndex, SegmentNode currentNode)
        {
            if (currentNode.LeftIndex == leftIndex && currentNode.RightIndex == rightIndex)
                return currentNode.Value;

            int midIndex = currentNode.LeftIndex + ((currentNode.RightIndex - currentNode.LeftIndex) / 2);

            if (rightIndex <= midIndex)
                return QueryInternal(leftIndex, rightIndex, currentNode.LeftNode);
            else if (leftIndex > midIndex)
                return QueryInternal(leftIndex, rightIndex, currentNode.RightNode);
            else
                return QueryInternal(leftIndex, midIndex, currentNode.LeftNode) +
                       QueryInternal(midIndex + 1, rightIndex, currentNode.RightNode);
        }

        // Time complexity: O(n)
        // Space complexity: O(n)
        private SegmentNode GenerateSegmentTree(int[] nums, int leftIndex, int rightIndex)
        {
            if (leftIndex == rightIndex)
                return new SegmentNode(nums[leftIndex], leftIndex, rightIndex);

            int midIndex = leftIndex + ((rightIndex - leftIndex) / 2);

            var segmentNode = new SegmentNode(0, leftIndex, rightIndex);

            segmentNode.LeftNode = GenerateSegmentTree(nums, leftIndex, midIndex);
            segmentNode.RightNode = GenerateSegmentTree(nums, midIndex + 1, rightIndex);

            segmentNode.Value = segmentNode.LeftNode?.Value + segmentNode.RightNode?.Value ?? 0;

            return segmentNode;
        }
    }
}
