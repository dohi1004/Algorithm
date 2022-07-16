using System;
using System.Collections.Generic;
public class Solution {
    public int solution(string numbers)
    {
        char[] numberArray = numbers.ToCharArray();
        List<int> numberList = new List<int>();
        List<int> indexList = new List<int>();
				// 각 문자열 추출
        for (int i = 0; i < numberArray.Length; i++)
        {
            numberList.Add(numberArray[i] - '0'); 
        }
				// 문자열 끼리 조합으로 모든 경우의 수 구하기
        for (int i = 1; i <= numberArray.Length; i++)  
        {
            plusNum(i, numberList, indexList, "");
        }
        int answer = 0;
				// 경우의 수 마다 소수인지 확인하기
        for (int i = 0; i < answerlist.Count; i++)
        {
            if (is_prime(answerlist[i])) answer++;
        }
        return answer;
    }

		// 경우의 수 구하기
    public List<int> answerlist = new List<int>();
    void plusNum(int stringNum, List<int> numberList, List<int> indexList, string makeNum)
    {
        string tempmakeNum = makeNum;
        for (int i = 0; i < numberList.Count; i++)
        { 
            if (!indexList.Contains(i))
            {
                makeNum = tempmakeNum + numberList[i].ToString();
                indexList.Add(i);
                int n = int.Parse(makeNum);
								// 현재 확인하고 있는 자릿 수 동일 + 아직 없는 수 -> 새로운 경우!
                if (stringNum == makeNum.Length && !answerlist.Contains(n)) answerlist.Add(n);
                // 현재 확인하고 있는 자릿 수와 다른 경우 -> 재귀! (현재 값 넘기면 다음 차례에 숫자들 붙이며 확인)
								else if (stringNum != makeNum.Length) plusNum(stringNum, numberList, indexList, makeNum);
                // 조합 만든 경우 -> 종이 조각 reset 
								indexList.RemoveAt(indexList.Count - 1);
            }
        }
    }
		// 소수인지 확인 (수의 제곱근 보다 크지 않은 어떤 소수로도 나누어지지 x) 
    public bool is_prime(int n)
    {
        int nr = (int)Math.Sqrt(n);
        for (int i = 2; i <= nr; i++)
        {
            if (n % i == 0) // 나누어지면 소수 아님!
                return false;
        }

        return true;
    }
}