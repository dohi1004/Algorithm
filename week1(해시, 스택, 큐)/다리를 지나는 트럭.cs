using System;
using System.Collections.Generic;
public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights) {
        int totalCount = truck_weights.Length;
        int time = 0;
        int answer = 0;
        int totalWeight = 0;
        Queue<int> truckQue = new Queue<int>(truck_weights);
        Queue<KeyValuePair<int,int>> runQue = new Queue<KeyValuePair<int,int>>();
        Queue<int> finQue = new Queue<int>();
        
        while(answer == 0)
        {
            time += 1;
            // 달리는 트럭 있으면 도착했는 지 확인하기
            if(runQue.Count != 0)
            {
                if(runQue.Peek().Value == time)
                {
                    int curWeight = runQue.Dequeue().Key;
                    finQue.Enqueue(curWeight);
                    totalWeight -= curWeight;
                }
            }
            // 현재 다리 위에 올라간 트럭 없으면 트럭 다리에 올리기
            if(runQue.Count == 0 && truckQue.Count != 0)
            {
                int curWeight = truckQue.Dequeue();
                // 현재 시간 + 다리 길이 -> 해당 시간 되면 다리 지나게 됨
                runQue.Enqueue(new KeyValuePair<int,int>(curWeight, time + bridge_length));
                totalWeight += curWeight;
            }
            else
            {
                if(truckQue.Count != 0)
                {
                    // 더 올라갈 수 있는 상태 
                    if(totalWeight + truckQue.Peek() <= weight)
                    {
                        int curWeight = truckQue.Dequeue();
                        runQue.Enqueue(new KeyValuePair<int,int>(curWeight, time + bridge_length));
                        totalWeight += curWeight;
                    }
                }
            }
            // 모든 트럭 도착 시 답 return
            if(finQue.Count == totalCount){answer = time;}
        }


        return answer;
    }
}