using System;
using System.Collections.Generic;

public class Solution {
    public string solution(int[] numbers) {
        List<string> init = new List<string>();
        
        foreach(int num in numbers) {init.Add(num.ToString());}

        // 두 값을 string으로 붙였을 때 더 큰 것을 기준으로 정렬
				// 6 + 10 = 610  vs  10 + 6 = 106
				// 33 + 30 = 3330 vs 30 + 33 = 3033
        init.Sort((a,b)=>(b+a).CompareTo(a+b));

				// list -> string
        string answer = string.Join("",init);

        if(answer[0] == '0') return "0";
        return answer;
    }
}