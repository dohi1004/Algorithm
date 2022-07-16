using System;
using System.Collections;
using System.Linq;

public class Solution {
    public int solution(int[] priorities, int location) {
        int count = 0; // 인쇄 순서 나타내기
        int answer = 0; // 결과 값
        Queue queue = new Queue(priorities);
        if(queue.Count == 1) return 1;
        while(answer == 0)
        {
            object max = queue.ToArray().Max(); 
            object currentDoc = queue.Dequeue(); // 제일 앞 문서 뽑기
            location -= 1; // 위치 한 칸 앞으로
            if((int)currentDoc < (int)max) // 뒤에 중요도 더 높은 문서 존재시
            {
                queue.Enqueue(currentDoc); // 제일 뒤로 보내기
                if(location == -1)
                {
                    location += queue.Count;
                }
            }
            else
            {
                count += 1; // 현재 가장 중요도 높음 -> 인쇄 순서에 포함시키기
                if(location == -1)
                {
                    answer = count;
                }
            }
        }       
        return answer;
    }
}