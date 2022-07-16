import heapq

def solution(scoville, K):
    answer = 0
    minHeap = []
    # 최소 힙에 넣기
    for sc in scoville:
        heapq.heappush(minHeap, sc)
    
    while(1):
		# 만약 모든 음식 섞었는데 k보다 작으면 -1 return
        if(len(minHeap) == 1 and minHeap[0] < K): return -1
		# 스코빌 지수 계산 과정
        min1 = heapq.heappop(minHeap)
        if(min1 >= K): break # 만약 K보다 크면 break
        min2 = heapq.heappop(minHeap)
        heapq.heappush(minHeap, min1+min2*2)
        answer += 1 
    return answer