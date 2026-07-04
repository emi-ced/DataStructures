namespace DataStructures
{
    // Queue with doubly-linked nodes.
    // TC: O(1)
    public class Deque
    {
        Node _headNode;
        Node _tailNode;
    
        int _count = 0;
    
        public Deque()
        {}
    
        public bool IsEmpty()
        {
            return _count == 0;
        }
    
        public void Append(int value)
        {
            var newNode = new Node(value);
    
            if (_count == 0)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                _tailNode.Next = newNode;
                newNode.Previous = _tailNode;
    
                _tailNode = newNode;
            }
    
            _count++;
        }
    
        public void AppendLeft(int value)
        {
            var newNode = new Node(value);
    
            if (_count == 0)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.Next = _headNode;
                _headNode.Previous = newNode;
    
                _headNode = newNode;
            }
    
            _count++;
        }
    
        public int Pop()
        {
            if (_count == 0)
                return -1;
            
            var value = _tailNode.Value;
            
            if (_count == 1)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                _tailNode = _tailNode.Previous;
                _tailNode.Next = null;
            }
    
            _count--;
            return value;
        }
    
        public int PopLeft()
        {
            if (_count == 0)
                return -1;
    
            var value = _headNode.Value;
    
            if (_count == 1)
            {
                _headNode = null;
                _tailNode = null;
            }
            else
            {
                _headNode = _headNode.Next;
                _headNode.Previous = null;
            }
    
            _count--;
            return value;
        }
    }
    
    public class Node
    {
        public Node Previous;
        public Node Next;
    
        public int Value;
    
        public Node(int value)
        {
            Value = value;
        }
    }

}
