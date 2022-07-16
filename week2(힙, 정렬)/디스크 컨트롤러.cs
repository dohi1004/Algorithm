using System;
using System.Collections.Generic;
using System.Numerics;

public class Job
{
    public int requestTime;
    public int taskTime;

    public Job(int requestTime, int taskTime)
    {
        this.requestTime = requestTime;
        this.taskTime = taskTime;
    }
}

public class Solution 
{
    public int solution(int[,] jobs)
    {
        List<Job> jobList = new List<Job>();
        for (int i = 0; i < jobs.GetLength(0); ++i)
        {
            Job job = new Job(jobs[i, 0], jobs[i, 1]);
            jobList.Add(job);
        }
				
				// 시작 시간 기준 정렬 
        jobList.Sort((a, b) =>
        {
            int requestTime = a.requestTime - b.requestTime;
				// 같은 경우 작업시간으로 정렬
            if (requestTime == 0) 
                return a.taskTime - b.taskTime;
            return requestTime;
        });

        int endTaskTime = 0;
        double sum = 0;
        while (jobList.Count > 0)
        {
            Job waitingJob = null;
            for (int i = 0; i < jobList.Count; i++)
            {
								// 아직 시작 못하는 경우
                if (jobList[i].requestTime > endTaskTime)
                    break;

                if (waitingJob == null)
                {
                    waitingJob = jobList[i];
                }
                else
                {
									// 작업 시간 비교 -> 더 짧은 것 실행 (둘 다 시작 가능한 상태!)
                    int priotyTime = waitingJob.taskTime - jobList[i].taskTime;
                    if (priotyTime == 0) // 같으면 요청 시간 더 짧았던 거 시작
                        priotyTime = waitingJob.requestTime - jobList[i].requestTime;
                    waitingJob = priotyTime <= 0 ? waitingJob : jobList[i];
                }
            }
						// 지금 시작 가능한 job 없는 경우
            if (waitingJob == null)
                waitingJob = jobList[0];
						// 현재 시간 - 요청 시간 = 미뤄진 시간 
            int delay = endTaskTime - waitingJob.requestTime;
            int ms = Math.Max(delay, 0) + waitingJob.taskTime;
						// 현재 시간 update 
						// 시작 가능한 경우 -> delay된 시간 + 작업 시간 (delay < 0)
						// 시작 불가능한 경우 -> 작업 시간 (delay > 0)
            endTaskTime += delay < 0 ? Math.Abs(delay) + waitingJob.taskTime : waitingJob.taskTime;
            sum += ms;
						// 끝난 Task 제거
            jobList.Remove(waitingJob);
        }

        return (int)(sum / jobs.GetLength(0));
    }
}