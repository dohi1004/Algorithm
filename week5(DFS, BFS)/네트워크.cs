using System;
using System.Collections.Generic;

public class Solution {
    bool[] visited; // 방문 여부 확인
    int num;
    public int solution(int n, int[,] computers) {
        int answer = 0;
        num = n;
        visited = new bool[n];
        
        for(int i = 0; i < n; i++) 
        {
            if(!visited[i]) // 만약 방문 안한 노드라면 -> dfs 시작
            {
                DFS(i, computers);
                answer += 1; // dfs로 연결된 네트워크 발견했으면 answer ++
            }   
        }
        return answer;
    }
    public void DFS(int now, int[,] computers)
    {
        visited[now] = true; // 방문 표시

        for(int i = 0; i < num; i++) 
        {
            if(!visited[i] && computers[now,i] == 1) // 연결된 노드 + 방문 안했으면 
            {
                DFS(i, computers);
            }
        }
    }
}