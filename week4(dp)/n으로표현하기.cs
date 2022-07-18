using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int solution(int N, int number) {
        if(number == N) return 1;
        int answer = 0;
        Dictionary<int,HashSet<int>> dp = new Dictionary<int,HashSet<int>>();        
        
        // 1개로 만든 수 = 자신
        dp.Add(1,new HashSet<int>());
        dp[1].Add(N);
        
        // 2개로 만든 수 ~ 8개로 만든 수까지 담기
        for(int i = 2; i <= 8; i++)
        {
            HashSet<int> tempList = new HashSet<int>();
            
            // N*숫자
            string n = "";
            for(int k = 0; k < i; k++)
            {
                n += N;
            }
            tempList.Add(int.Parse(n));
            
            for(int k = 1; k < i; k++)
            {
								// set -> 리스트로 변환 (index 접근 위해!) 
                List<int> dp1 = dp[k].ToList();
                List<int> dp2 = dp[i-k].ToList();
                for(int a = 0; a < dp[k].Count; a++)
                {
                    for(int m = 0; m < dp[i-k].Count; m++)
                    {
                        tempList.Add(dp1[a]+dp2[m]);
                        tempList.Add(dp1[a]-dp2[m]);
                        tempList.Add(dp1[a]*dp2[m]);
                        if(dp2[m] != 0)
                            tempList.Add(dp1[a]/dp2[m]);
                    }
                }
            }
            
            if(tempList.Contains(number))
            {
                answer = i;
                break;
            }
            
            dp.Add(i, tempList);
        }
        if(answer == 0) {answer = -1;}
        return answer;
    }
}