using System;
class Solution
    {
        public int solution(string name)
        {
            int answer = 0;
            int n = name.Length;
            int leftOrRight = name.Length - 1;
            for (int i = 0; i < n; i++)
            {
                int next = i + 1;
                char target = name[i];
								// 조이 스틱 상하 움직임 
                if (target <= 'N') answer += target - 'A'; //첫 알파벳이 A~N
                else answer += 'Z' - target + 1; //첫 알파벳이  O~Z

                // 조이 스틱 좌우 움직임
								// case1: 오른쪽으로 쭉 (A가 맨끝 or A 없음 or A 개수 < 오른쪽 이동 수)
								// case2: 오른쪽가다가 왼쪽으로
                while (next < n && name[next] == 'A') next++;
								// n - next : 현재 커서 바로 다음의 연속된 A 지나고 남은 알파벳 수
								// i: 오른쪽으로 현재 커서 이동 수
								// 마지막 Math.Min -> 만약 맨끝이 A면 해당 값이 최소가 됨(BCCCAAAA)
                leftOrRight = Math.Min(leftOrRight, i + n - next + Math.Min(i, n - next));
            }
            answer += leftOrRight;
            return answer;
        }
    }