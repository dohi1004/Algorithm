using System;
using System.Collections.Generic;
public class Solution {
    public string solution(string number, int k) {
        string answer = "";
        Stack<int> numberStack = new Stack<int>();
        
				// 제일 앞을 크게 만들기 (스택 사용) -> 다음 숫자가 크면 앞에 거 빼는 방식
        for(int i = 0; i < number.Length; i++)
        {
            int curNum = Int32.Parse(number[i].ToString());
            while(k > 0 && numberStack.Count != 0 && numberStack.Peek() < curNum)
            {
                numberStack.Pop();
                k -= 1;
            }
            numberStack.Push(curNum);
        }
        
        // 만약 정렬된 형태라 k가 변하지 않는 경우 (스택에 다 push된 경우) ex) 9, 8, 7, 6
        while(k > 0 && numberStack.Count != 0)
        {
            numberStack.Pop();
            k -= 1;
        }
        
        
        List<int> answerList = new List<int>(numberStack);
        answerList.Reverse(); // 스택에 쌓여 있어서 출력할 때는 뒤집기
        answer = string.Join("",answerList);
        
        return answer;
    }
}