using System;
using System.Collections.Generic;

class Solution {
    int sizeX;
    int sizeY;
    int destX;
    int destY;
    public int solution(int[,] maps) {
        sizeX = maps.GetLength(0);
        sizeY = maps.GetLength(1);
        destX = sizeX - 1;
        destY = sizeY - 1;
        
        int answer = AStar(0,0, maps); // 캐릭터 위치 -> 시작
        
        return answer;
    }
    
    struct PQNode : IComparable<PQNode>
    {
        public int F;
        public int G;
        public int Y;
        public int X;
        
        public int CompareTo(PQNode other)
        {
            if(F == other.F) return 0;
            return F < other.F ? 1 : -1; // 작은 경우가 더 좋으므로! (G+H)
        }
    }
    
    public int AStar(int curX, int curY, int[,] maps)
    
        // 상하 좌우 탐색 위함
        int[] deltaX = new int[] {-1,0,1,0};
        int[] deltaY = new int[] {0,-1,0,1};
        
        bool[,] closed = new bool[sizeX, sizeY]; // 방문 여부 check (이미 지나간 길)
        int[,] open = new int[sizeX, sizeY]; // 갈 수 있는 길 (x -> maxVal, o -> F 계산)
        
        // 초기화
        for(int x = 0; x < sizeX; x++)
        {
            for(int y = 0; y < sizeY; y++)
            {
                open[x,y] = Int32.MaxValue;
            }
        }
        
        open[curX, curY] = Math.Abs(destX - curX) + Math.Abs(destY - curY);
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();
        
        pq.Push(new PQNode() {F = open[curX, curY], G = 0, Y = curY, X = curX});

        while(pq.Count > 0)
        {   
            PQNode node = pq.Pop();
            if(closed[node.X, node.Y]) continue; // 더 빠른 경로로 이미 지나간 경우 -> skip
            closed[node.X, node.Y] = true; // 방문 표시
            
            if(node.Y == destY && node.X == destX) return node.G+1; // 목적지 도달 시 종료
            
            // 상하 좌우 이동 가능한지 확인
            for(int i = 0; i < 4; i++)
            {
                int nextX = node.X + deltaX[i];
                int nextY = node.Y + deltaY[i];
                
                // 유효 범위 벗어남 -> skip
                if(nextY < 0 || nextX < 0 || nextY >= sizeY || nextX >= sizeX) continue;
                // 벽으로 막혀서 갈 수 없으면 skip
                if(maps[nextX, nextY] == 0) continue;
                // 이미 방문한 곳이면 skip
                if(closed[nextX, nextY]) continue;
                
                // 비용 계산
                int g = node.G + 1;
                int h = Math.Abs(destY - nextY) + Math.Abs(destX - nextX); // 목적지와의 거리
                if(open[nextX, nextY] < g+h) continue; // 이미 다른 경로에서 더 빠른 길 찾은 경우
                
                open[nextX, nextY] = g+h; // 현재가 제일 빠른 경우
                pq.Push(new PQNode() {F = open[nextX, nextY], G = g, Y= nextY, X = nextX});
            }
        }
        
        
        return -1;
    }
    
    
}
// 우선순위 큐 구현
class PriorityQueue<T> where T: IComparable<T> 
{
    List<T> heap = new List<T>();
    
    public void Push(T data)
    {
        heap.Add(data);
        int now = heap.Count - 1;
        while(now > 0)
        {
            int next = (now-1)/2;
            if(heap[now].CompareTo(heap[next]) < 0) break;
            T temp = heap[now];
            heap[now] = heap[next];
            heap[next] = temp;
            
            now = next;
        }
    }
    
    public T Pop()
    {
        T ret = heap[0];
        
        int lastIndex = heap.Count - 1;
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);
        lastIndex--;
        
        int now = 0;
        while(true)
        {
            int left = 2*now+1;
            int right = 2*now+2;
            
            int next = now;
            if(left <= lastIndex && heap[next].CompareTo(heap[left]) < 0) // 왼쪽 > 현재 -> 왼쪽으로 이동
            {
                next = left;
            }
            if(right <= lastIndex && heap[next].CompareTo(heap[right]) < 0) // 오른쪽 > 현재 -> 오른쪽으로 이동
            {
                next = right;
            }
            if(next == now) break; // 왼쪽, 오른쪽 모두 현재보다 작으면 종료 
            
            T temp = heap[now];
            heap[now] = heap[next];
            heap[next] = temp;
            now = next;
        }
        
        return ret;
    }
    public int Count {get {return heap.Count;}}
}