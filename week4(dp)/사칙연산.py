def solution(arr):
    minmax = [0,0]
    sumval = 0
    for i in range(len(arr)-1, -1, -1):
        if arr[i] == '+':
            continue
        elif arr[i] == '-':
            tempmin, tempmax = minmax
            # 최소: -(최대) or -(sum) + 최소
            minmax[0] = min(-(sumval + tempmax), -sumval + tempmin)
            # 현재 값에 - 붙이기 
            minusval = int(arr[i+1])
            # 최대: -(최소) or -(현재 index) + sum + 최대
            minmax[1] = max(-(sumval + tempmin), -minusval + (sumval - minusval) + tempmax)
            sumval = 0 # 현재 -까지 sum 초기화 
        elif int(arr[i]) >= 0: # sum에 포함 시키기
            sumval += int(arr[i])
    minmax[1] += sumval
    return minmax[1]