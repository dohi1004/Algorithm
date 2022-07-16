using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int[] answers) {
        List<int> answer = new List<int>();
        int score1, score2, score3;
        score1 = score2 = score3 = 0;
        
        int[] answer1 = new int[] {1,2,3,4,5};
        int[] answer2 = new int[] {2,1,2,3,2,4,2,5};
        int[] answer3 = new int[] {3,3,1,1,2,2,4,4,5,5};
        
        for(int i = 0; i < answers.Length; i++)
        {
            score1 += check(answer1,i,answers);
            score2 += check(answer2,i,answers);
            score3 += check(answer3,i,answers);
        }
        List<int> tempList = new List<int>();
        tempList.Add(score1);
        tempList.Add(score2);
        tempList.Add(score3);
        int max = tempList.Max();

				// 최대 값인 경우 해당 학생 번호 추가하기
        for(int i = 0 ; i < tempList.Count; i++)
        {
            if(tempList[i] == max) answer.Add(i+1);
        }
        
        return answer.ToArray();
    }
    // 정답 인지 확인하는 함수
    public int check(int[] answer, int i, int[] answers)
    {
        return answers[i] == answer[i%answer.Length] ? 1 : 0;
    }
}