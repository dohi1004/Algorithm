def solution(routes):
    answer = 0
    rangeX = 30000
    routes.sort(key = lambda x : x[0], reverse = True)

    for i in range(len(routes)):
        if routes[i][1] < rangeX: 
            answer += 1 # 카메라 설치
            rangeX = routes[i][0] # 현재 설치한 진입 지점으로 변경
            
    return answer