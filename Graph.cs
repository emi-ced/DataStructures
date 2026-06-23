namespace DataStructures
{
  public class Graph
  {
      Dictionary<int, HashSet<int>> _nodes;
  
      public Graph()
      {
          _nodes = new();
      }
  
      public void AddEdge(int src, int dst)
      {
          if (!_nodes.ContainsKey(src))
              _nodes.Add(src, new HashSet<int>());
  
          if (!_nodes.ContainsKey(dst))
              _nodes.Add(dst, new HashSet<int>());
  
          _nodes[src].Add(dst);
      }
  
      public bool RemoveEdge(int src, int dst)
      {
          if (!_nodes.ContainsKey(src))
              return false;
  
          if (_nodes[src].Contains(dst))
          {
              _nodes[src].Remove(dst);
              return true;
          }
  
          return false;
      }
  
      public bool HasPath(int src, int dst)
      {
          return DFS(src, dst, new HashSet<int>());
      }
  
      private bool DFS(int cur, int dst, HashSet<int> visitedNodes)
      {
          if (cur == dst)
              return true;
  
          if (visitedNodes.Contains(cur))
              return false;
  
          visitedNodes.Add(cur);
  
          foreach (var tempCur in _nodes[cur])
          {
              var exists = DFS(tempCur, dst, visitedNodes);
  
              if (exists)
                  return true;
          }
  
          return false;
      }
  }
}
