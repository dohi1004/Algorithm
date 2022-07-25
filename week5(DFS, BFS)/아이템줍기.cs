using System;
using System.Collections.Generic;

public class Solution {
    bool[,] visited;
    int answer;
    public int solution(int[,] rectangle, int characterX, int characterY, int itemX, int itemY) {
        answer = 0;
        int[,] board = new int[101,101];
				// scale 2배 -> 경로가 이어지지 않았음에도 좌표가 바로 인접해있는 경우 있음
        int cX = characterX*2;
        int cY = characterY*2;
        int iX = itemX*2;
        int iY = itemY*2;
        visited = new bool[101,101];
        
        // 사각형 전체 테두리 경로 구하기
        // 1. 직사각형 테두리 ~ 내부 => 전부 1로 만들기
        for(int i = 0; i < rectangle.GetLength(0); i++)
        {
            for(int sx = rectangle[i,0]*2; sx <= rectangle[i,2]*2; sx++)
            {
                for(int sy = rectangle[i,1]*2; sy <= rectangle[i,3]*2; sy++)
                {
                    board[sx,sy] = 1;
                }
            }
        }
        // 2. 직사각형 내부 => 전부 0으로 만들기
        for(int i = 0; i < rectangle.GetLength(0); i++)
        {
            for(int sx = rectangle[i,0]*2+1; sx <= rectangle[i,2]*2-1; sx++)
            {
                for(int sy = rectangle[i,1]*2+1; sy <= rectangle[i,3]*2-1; sy++)
                {
                    board[sx,sy] = 0;
                }
            }
        }
        
        BFS(board, cX, cY, iX, iY); 

        return answer;
    }
    
    struct Node
    {
        public int X;
        public int Y;
    }
    
    public void BFS(int[,] board, int beginX, int beginY, int destX, int destY)
    {
        int[] deltaX = new int[] {-1,0,1,0};
        int[] deltaY = new int[] {0,-1,0,1};
        
        Queue<Node> q = new Queue<Node>();
        
        q.Enqueue(new Node() {X = beginX, Y = beginY});
        
        while(q.Count > 0)
        {
            Node node = q.Dequeue();
						// 도달하면 scale 다시 반으로 줄여 반환
            if(node.X == destX && node.Y == destY) {answer = board[node.X,node.Y]/2; break;}
            if(!visited[node.X, node.Y])
            {
                visited[node.X, node.Y] = true;
                for(int i = 0; i < 4; i++)
                {
                    int nextX = node.X + deltaX[i];
                    int nextY = node.Y + deltaY[i];
                    
                    if(nextX >= 0 && nextY >= 0 && nextX < 101 && nextY < 101 
                       && board[nextX,nextY] != 0 && !visited[nextX,nextY])
                    {
                        board[nextX, nextY] = board[node.X, node.Y] + 1;
                        q.Enqueue(new Node(){X = nextX, Y = nextY});
                    }
                }
            }
        }
    }
}