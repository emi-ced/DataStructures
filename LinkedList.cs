namespace DataStructures
{
    public class SinglyLinkedListNode
    {
        public int Value;
        public SinglyLinkedListNode Next;
    
        public SinglyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class SinglyLinkedList
    {
        private SinglyLinkedListNode _headNode;
        private SinglyLinkedListNode _tailNode;
        private int _count = 0;
    
        public LinkedList()
        {}
    
        public int Get(int index)
        {
            if (index >= _count)
                return -1;
    
            SinglyLinkedListNode node = _headNode;
            
            while (index > 0)
            {
                node = node.Next;
                index--;
            }
    
            return node.Value;
        }
    
        public void InsertHead(int val) 
        {
            var newNode = new SinglyLinkedListNode(val);
    
            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            else
            {
                newNode.Next = _headNode;
                _headNode = newNode;
            }
    
            _count++;
        }
    
        public void InsertTail(int val)
        {
            var newNode = new SinglyLinkedListNode(val);
    
            if (_tailNode == null)
            {
                _tailNode = newNode;
                _headNode = newNode;
            }
            else
            {
                _tailNode.Next = newNode;
                _tailNode = newNode;
            }
    
            _count++;
        }
    
        public bool Remove(int index)
        {
            if (index >= _count)
                return false;
    
            if (index == 0)
            {
                _headNode = _headNode.Next;
            }
            else
            {
                var node = _headNode;
    
                while (index > 1)
                {
                    node = node.Next;
                    index--;
                }
    
                node.Next = node.Next.Next;
    
                if (index == (_count - 1))
                    _tailNode =  node;
            }
    
            _count--;
    
            if (_count == 0)
            {
                _headNode = null;
                _tailNode = null;
            }
            else if (_count == 1)
            {
                _headNode = _headNode ?? _tailNode;
                _tailNode = _tailNode ?? _headNode;
            }
    
            return true;
        }
    
        public List<int> GetValues()
        {
            List<int> values = new();
    
            SinglyLinkedListNode node = _headNode;
    
            while (node != null)
            {
                values.Add(node.Value);
                node = node.Next;
            }
    
            return values;
        }
    }
     

    public class DoublyLinkedListNode
    {
        public int Value { get; set; }
        public DoublyLinkedListNode Previous { get; set; }
        public DoublyLinkedListNode Next { get; set; }
    
        public DoublyLinkedListNode(int value)
        {
            Value = value;
        }
    }

    public class DoublyLinkedList
    {
        DoublyLinkedListNode _headNode;
        DoublyLinkedListNode _tailNode;
    
        int _nodeCount;
    
        public DoublyLinkedList() {}
    
        public int Get(int index)
        {
            if (index >= _nodeCount)
                return -1;
    
            var currentNode = _headNode;
            for (int i = 0; i < index; i++)
                currentNode = currentNode.Next;
    
            return currentNode.Value;    
        }
        
        public void AddAtHead(int val)
        {
            var newNode = new DoublyLinkedListNode(val);
    
            if (_headNode == null)
            {
                _headNode = newNode;
                _tailNode = newNode;
            }
            {
                newNode.Next = _headNode;
                _headNode.Previous = newNode;
    
                _headNode = newNode;
            }
    
            _nodeCount += 1;    
        }
        
        public void AddAtTail(int val)
        {
            var newNode = new DoublyLinkedListNode(val);
    
            if (_tailNode == null)
            {
                _tailNode = newNode;
                _headNode = newNode;
            }
            else
            {
                newNode.Previous = _tailNode;
                _tailNode.Next = newNode;
    
                _tailNode = newNode;
            }
    
            _nodeCount += 1;
        }
        
        public void AddAtIndex(int index, int val)
        {
            if (index > _nodeCount)
                return;
    
            if (index == 0)
                AddAtHead(val);
            else if (index == _nodeCount)
                AddAtTail(val);
            else
            {
                var currentNode = _headNode;
                for (int i = 0; i < index; i++)
                    currentNode = currentNode.Next;
    
                var newNode = new DoublyLinkedListNode(val);
                newNode.Next = currentNode;
                newNode.Previous = currentNode.Previous;
    
                currentNode.Previous.Next = newNode;
                currentNode.Previous = newNode;
    
                _nodeCount += 1;    
            }
        }
        
        public void DeleteAtIndex(int index)
        {
            if (index >= _nodeCount)
                return;
    
            if (_nodeCount == 1)
            {
                _headNode = null;
                _tailNode = null;
            }
            else if (index == 0)
            {
                _headNode.Next.Previous = null;
                _headNode = _headNode.Next;
            }
            else if (index == _nodeCount - 1)
            {
                _tailNode.Previous.Next = null;
                _tailNode = _tailNode.Previous;
            }
            else
            {
                var currentNode = _headNode;
                for (int i = 0; i < index; i++)
                    currentNode = currentNode.Next;
    
                currentNode.Previous.Next = currentNode.Next;
                currentNode.Next.Previous = currentNode.Previous;
            }
    
            _nodeCount -= 1;    
        }
    }
}
