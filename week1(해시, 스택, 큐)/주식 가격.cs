using System;
using System.Collections.Generic;
public class Solution {
    public int[] solution(int[] prices) {
        List<int> answer = new List<int>();
        Queue<int> priceQue = new Queue<int>(prices);
        for(int i = 0; i < prices.Length; i++)
        {
            bool isFall = false;
            int now = priceQue.Dequeue();
            int time = 1;
            for(int j = i+1; j < prices.Length; j++)
            {
                if(now > prices[j]){answer.Add(time); isFall = true; break; }
                time += 1;
            }
            if(!isFall){answer.Add(priceQue.Count);}
        }
        return answer.ToArray();
    }
}