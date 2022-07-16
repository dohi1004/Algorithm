using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] progresses, int[] speeds) {
        List<int> answer = new List<int>();
        Queue<KeyValuePair<int,int>> queue = new Queue<KeyValuePair<int,int>>();
        for(int i=0; i<progresses.Length; i++)
        {
            queue.Enqueue(new KeyValuePair<int,int>(speeds[i],progresses[i]));
        }
        while(queue.Count != 0)
        {
            if(queue.Count == 1){answer.Add(1); break;}
            int count = 1;
            var top = queue.Dequeue(); // 제일 앞 작업 가져오기
            // 제일 앞 기능 필요한 개발 시간 구하기
            int remain = (100 - top.Value)%top.Key;
            int time = (remain == 0) ? (100 - top.Value)/top.Key : (100 - top.Value)/top.Key+1;
            bool pass = false; // 앞의 기능 끝나지 않았는지 확인 기능

            int queueLen = queue.Count;
            for(int i=0; i<queueLen; i++)
            {
                var cur = queue.Dequeue();
                int newProgress = cur.Value + cur.Key * time;
                if(newProgress >= 100 && !pass){count += 1;} 
                else{
                    pass = true;
                    queue.Enqueue(new KeyValuePair<int,int>(cur.Key, newProgress));
                }
            }
            answer.Add(count);
            
        }
        
        return answer.ToArray();
    }
}