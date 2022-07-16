using System;

public class Solution {
    public int[] solution(int brown, int yellow) {
        int width = 3;
        int length = 3;

        for(int i = 1; i < yellow+1; i++)
        {
            if(yellow % i == 0) // 노란색 사각형 만드는 조건 
            {
                width = yellow/i + 2;
                length=  i + 2;
								// 갈색 타일도 조건 만족 + 가로 길이 >= 세로 길이
                if((width * 2) + (length * 2) - 4 == brown && width >= length) {break;}
            }
        }
        int[] answer = new int[] {width, length};
        return answer;
    }
    
}