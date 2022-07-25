using System;

public class Solution {
    int target, answer;
    public int solution(int[] numbers, int t) {
        answer = 0;
        target = t;
        DFS(numbers, 0, 0);
        return answer;
    }
    
    public void DFS(int[] numbers, int now, int sum)
    {
        if(now < numbers.Length) // 전체 numbers 수 만큼 아직 안 돌았으면 
        {
            DFS(numbers, now+1, sum + numbers[now]); // + 하기
            DFS(numbers, now+1, sum - numbers[now]); // - 하기
        }
        else if(sum == target) // 전체 수만큼 돌고, 원했던 target만들어냈으면 
        {
            answer ++;
        }
    }
}