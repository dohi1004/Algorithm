using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int solution(int[] citations) {
        int answer = 0;
        List<int> citationList = new List<int>(citations);
        List<int> resultList = new List<int>();
        citationList.Sort(); // 정렬
        int length = citationList.Count; // 총 논문 수 (예제 기준, 5개) 
        
        for(int i = 0; i < length; i++)
        {
            if((length-i) >= citationList[i]) // h번 이상 논문의 수 >= h번
            {
                resultList.Add(citationList[i]);
            }
            else
            {
                if(resultList.Count != 0)
                {
										// [0, 1, 3, 3, 5, 5, 6, 6] 다음과 같은 경우!
										// 3~5 사이에서 조건 만족시 resultList에 추가
                    for(int j = resultList.Max(); j <= citationList[i]; j++)
                    {
                        if((length-i) >= j){resultList.Add(j);} // h번 이상 논문 수 >= h번
                    }
                }
                else // [10, 10, 10, 10, 10] 경우 
                {
                    return citations.Length; // 총 길이가 답!
                }
                
                break;
            }
        }
        answer = resultList.Max();
        return answer;
    }
}