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
        
        BFS(0,0, maps); // 캐릭터 위치 -> 시작
        if(maps[destX,destY] == 1) return -1;
        else return maps[destX,destY];
    }
    
    struct Node
    {
        public int Y;
        public int X;
    }
    
    public void BFS(int curX, int curY, int[,] maps)
    {
        bool[,] visited = new bool[sizeX,sizeY]; // 방문 여부 확인
        // 상하 좌우 탐색 위함
        int[] deltaX = new int[] {-1,0,1,0};
        int[] deltaY = new int[] {0,-1,0,1};
        
        Queue<Node> q = new Queue<Node>();
        q.Enqueue(new Node() {Y = curY, X = curX});

        while(q.Count > 0)
        {   
            Node node = q.Dequeue();
            if(visited[node.X, node.Y]) continue;
            visited[node.X, node.Y] = true;
      
            // 상하 좌우 이동 가능한지 확인
            for(int i = 0; i < 4; i++)
            {
                int nextX = node.X + deltaX[i];
                int nextY = node.Y + deltaY[i];
                
                // 유효 범위 벗어남 -> skip
                if(nextY < 0 || nextX < 0 || nextY >= sizeY || nextX >= sizeX) continue;
                // 벽으로 막혀서 갈 수 없으면 skip
                if(maps[nextX, nextY] == 0) continue;
                if(maps[nextX,nextY] == 1)
                {
                    maps[nextX, nextY] = maps[node.X,node.Y] + 1;
                    q.Enqueue(new Node() {Y= nextY, X = nextX});
                }
            }
        }
    }
}