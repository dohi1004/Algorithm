using System;
using System.Collections.Generic;

public class PriorityQueue
{
    List<int> _heap = new List<int>();
    
    public void Push(int data)
    {
        _heap.Add(data);
        
        int now = _heap.Count - 1;
        while(now > 0)
        {
            int next = (now-1)/2; // 부모 
            if(_heap[now] <= _heap[next]) break;
            // 들어온 데이터 > 부모 -> swap
            int temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;
            
            now = next; // 검사 위치 이동
        }
    }
    public int Pop()
    {
        int ret = _heap[0];
        
        // 마지막 데이터 루트로 이동
        int lastIndex = _heap.Count - 1;
        _heap[0] = _heap[lastIndex];
        _heap.RemoveAt(lastIndex);
        lastIndex--;
        
        int now = 0; // 현재
        while(true)
        {
            int left = 2 * now + 1;
            int right= 2 * now + 2;
            
            int next = now; 
            if(left <= lastIndex && _heap[next] < _heap[left]) next = left;
            if(right <= lastIndex && _heap[next] < _heap[right]) next = right;
            if(next == now) break;
            
            int temp = _heap[now];
            _heap[now] = _heap[next];
            _heap[next] = temp;
            
            now = next;
        }
        return ret;
    }
    public void Remove(int data)
    {
        _heap.Remove(data);
    }
    public int Count()
    {
        return _heap.Count;
    }
}


public class Solution {
    public int[] solution(string[] operations) {
        List<string[]> operationList = new List<string[]>();
        List<int> answer = new List<int>();
        PriorityQueue maxPq = new PriorityQueue();
        PriorityQueue minPq = new PriorityQueue();
        
        // 공백 기준 분리해서 넣기
        foreach(var op in operations) {operationList.Add(op.Split(' '));}
        
        foreach(var op in operationList)
        {
            // 명령어: 삽입
            if(op[0] == 'I'.ToString())
            {
                maxPq.Push(Int32.Parse(op[1]));
                minPq.Push(-Int32.Parse(op[1]));
            }
            // 명령어: 최대값 삭제
            else if(op[1] == 1.ToString())
            {
                if(maxPq.Count() != 0)
                {
                    int temp = maxPq.Pop();
                    minPq.Remove(-temp);
                }
            }
            // 명령어: 최소값 삭제
            else
            {
                if(minPq.Count() != 0)
                {
                    int temp = minPq.Pop();
                    maxPq.Remove(-temp);
                }
            }
        }

        if(minPq.Count() == 0 && maxPq.Count() == 0) {answer.Add(0); answer.Add(0);}
        else{answer.Add(maxPq.Pop()); answer.Add(-minPq.Pop());}
        return answer.ToArray();
        
    }
}