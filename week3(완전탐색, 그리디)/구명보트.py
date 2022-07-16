from collections import deque

def solution(people, limit):
    answer = 0
    people.sort()
    q = deque(people)
    
    while(q):
        # 아직 2명 이상 존재 시
        if(len(q) >= 2):
            # 무게 큰 + 작은 조합이 limit 안 넘으면
            if(q[0] + q[-1] <= limit):
                answer += 1
                q.pop()
                q.popleft()
            else: # 안 되면 무게 큰 애만 뺌
                answer += 1
                q.pop()
        else: # 큐에 하나만 남은 경우
            answer += 1
            q.pop()
            
                
    return answer