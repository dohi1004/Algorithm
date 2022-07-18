def solution(money):
    answer = 0
		# 만약 3집 밖에 없으면 그 중 최대값 하나 return 
    if(len(money) == 3): return max(money[0],money[1],money[2])
    dp = [0] * len(money)
    dpFinal = [0]*len(money) # 원이므로, 마지막 집 고려 위함
		# base case
    dp[0] = money[0]
    dp[1] = money[1]
    dp[2] = money[0] + money[2]
		
    dpFinal[1] = money[1]
    dpFinal[2] = money[2] 

		# dp
    for i in range(3,len(money)): 
        dp[i] = max(dp[i-2], dp[i-3]) + money[i] # 현재 집 + 앞 or 앞앞 집 털었던 것 중 최대 값
        dpFinal[i] = max(dpFinal[i-2],dpFinal[i-3])+money[i] # 첫번째 집 제외하고 돌린 케이스!
    # 최종 답: 맨끝 세 집 확인 (맨 끝 집 -> doFinal(첫 집 제외한 케이스))
    # 나머지 끝에서 두 집: 첫 집 포함한 케이스로 -2집은 자신 앞 케이스는 고려안했으므로 -3집까지 봄!    
    answer = max(dpFinal[len(money)-1], dp[len(money)-2], dp[len(money)-3])
    return answer