def solution(triangle):
    answer = 0
    dp = [[] for _ in range(len(triangle))] # 이중 리스트 초기화
    dp[0].append(triangle[0][0]) # Base case

    for i in range(1,len(triangle)): 
        length = len(triangle[i])
        for j in range(length):
            now = triangle[i][j] # 현재 값
            if(j != 0 and j != length-1): # 중간에 위치한 값 (화살표 2개)
                curmax = dp[i-1][j-1] if dp[i-1][j-1]> dp[i-1][j] else dp[i-1][j] # 오는 것 중 최대 값에다 현재 값 더한 것 넣기
                dp[i].append(curmax + now)
            else: 
                if(j == 0): dp[i].append(dp[i-1][j]+now) # 제일 끝에 위치한 값이면 이전 제일 끝에 위치한 값 + 현재 값 (화살표 1개)
                else: dp[i].append(dp[i-1][j-1]+now)
                
    answer = max(dp[-1]) # 만들어진 케이스들 중 최대 값
    return answer
