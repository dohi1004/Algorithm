using System;
using System.Collections.Generic;

public class Solution {
    int answer;
    bool[] visited;
    public int solution(string begin, string target, string[] words) {
        answer = 0;
        visited = new bool[words.Length];
        List<string> wordList = new List<string>(words);
        if(!wordList.Contains(target)){return 0;} // target 단어 words에 없으면 0 반환
        DFS(begin,target,words,0); 
        return answer;
    }
    
    public void DFS(string begin, string target, string[] words, int p)
    {   
        for(int i = 0; i < words.Length; i++)
        {
            int n = 0;
            if(!visited[i]) // 사용하지 않은 단어라면
            {
                for(int j = 0; j < words[i].Length; j++) 
                {
                    if(begin[j] == words[i][j]) // 공통되는 문자 길이 비교
                    {
                        n++;
                    }
                }
                if(n == begin.Length - 1) // 만약 하나만 차이나면
                {
                    begin = words[i]; // 단어 변환
                    visited[i] = true; // 방문 표시
                    if(begin == target) answer = p+1; // 목표지점이면 거쳐온 횟수 반환
                    else
                    {
                        DFS(begin, target, words, p+1); // 목표 단어 아니면 그 다음 단어 찾기
                    }
                }
            }
            
        }
    }
}