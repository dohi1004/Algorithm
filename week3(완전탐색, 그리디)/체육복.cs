using System;

public class Solution {
    public int solution(int n, int[] lost, int[] reserve) {
        int answer = 0;
        Array.Sort(lost);
        Array.Sort(reserve);
        
				// 전처리 -> 여분 가지고 있지만 도난 당한 경우 (못 빌려줌)
        for(int i = 0; i < lost.Length; i++)
        {
            for(int j = 0; j < reserve.Length; j++)
            {
                if(reserve[j] == lost[i])
                {
                    answer ++;
                    reserve[j] = -1;
                    lost[i] = -1;
                }
            }
        }

        for(int i = 0; i < lost.Length; i++)
        {
            for(int j = 0; j < reserve.Length; j++)
            {
								// 왼쪽 오른쪽 모두 가능하다면 
								// 왼쪽을 먼저 빌려주는 게 더 많은 사람에게 빌려주기 가능!
                if(reserve[j] == lost[i] - 1)
                {
                    reserve[j] = -1;
                    answer ++;
                    break;
                }
                else if(reserve[j] == lost[i] + 1)
                {
                    reserve[j] = -1;
                    answer ++;
                    break;
                }
            }
        }
        
        return n - lost.Length + answer;
    }
}