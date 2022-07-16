using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        List<int> answer = new List<int>(); 
        List<int> arrayList = new List<int>(array); 
        
        for(int i = 0; i < commands.GetLength(0); i++)
        {
						// i~j까지 array로부터 복사한 리스트 생성
            List<int> temp = arrayList.GetRange(commands[i,0]-1, commands[i,1]-commands[i,0]+1);
            // 리스트 정렬
						temp.Sort();
						// 정렬된 리스트에서 원하는 위치의 값 답에 추가
            answer.Add(temp[commands[i,2]-1]);
        }
        
        return answer.ToArray();
    }
}