using System;
using System.Collections.Generic;

public class Solution {
    public int solution(string[,] clothes) {
        int answer = 1;
        // 의상 종류 , 개수
        Dictionary<string,int> dict = new Dictionary<string,int>();
        for(int i = 0; i < clothes.GetLength(0); i++)
        {
            if(dict.ContainsKey(clothes[i,1])){dict[clothes[i,1]] += 1;}
            else{dict[clothes[i,1]] = 1;}
        }
        foreach(KeyValuePair<string, int> cloth in dict)
        {
            answer = answer * (cloth.Value+1);
        }
        answer -= 1;
        return answer;

    }
}