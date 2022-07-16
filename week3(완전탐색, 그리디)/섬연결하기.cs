using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int n, int[,] costs) {
        int[,] distance = new int[n,n];
        // 초기화 (길 없는 경우 -1)
        for(int i = 0; i < n; i++)
        {
            for(int j = 0; j < n; j++)
            {
                distance[i,j] = -1;
            }
        }
				// [시작, 도착] = 비용
        for(int i = 0; i < costs.GetLength(0); i++)
        {
            distance[costs[i,0],costs[i,1]] = costs[i,2];
            distance[costs[i,1],costs[i,0]] = costs[i,2];
        }
        
        HashSet<int> nodes = new HashSet<int>();
        nodes.Add(0); // node 0 부터 확인 시작 
        int minIndex = -1;
        int answer = 0;
        while(nodes.Count < n) // node 모두 방문할 때까지
        {
            int min = 999999;
            foreach(int cur in nodes) // 0번과 연결 가능한 node 찾기
            {
                for(int i = 0; i < n; i++)
                {
										// 현재 방문 안함 + 길 존재 + 가장 짧은 거리
                    if(!nodes.Contains(i) && distance[cur,i] != -1 && distance[cur,i] < min)
                    {
                        min = distance[cur,i];
                        minIndex = i;        
                    }
                }
            }
            answer += min;
            nodes.Add(minIndex);
        }
        return answer;
    }
}