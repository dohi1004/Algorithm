using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        List<int> answer = new List<int>();
        // 1번 룰 적용 위한 장르 내 total song 개수 저장 위한 dictionary
        Dictionary<string,int> totalPlayDict = new Dictionary<string,int>();
        // 2,3번 룰 적용 위한 장르를 key로 하고 해당되는 song을 순서로 담고 있음 
        Dictionary<string,List<int>> genreDict = new Dictionary<string,List<int>>(); 
        // 최종 결과 추출 위해 song 개수와 index 반환 
        Dictionary<int, List<int>> originDict = new Dictionary<int,List<int>>();
        
        // 초기화
        for(int i = 0; i < genres.Length; i++)
        {
            if(originDict.ContainsKey(plays[i])){originDict[plays[i]].Add(i);}
            else{originDict[plays[i]] = new List<int>{i};}
            
            
            if(totalPlayDict.ContainsKey(genres[i])){totalPlayDict[genres[i]] += plays[i];}
            else{totalPlayDict[genres[i]] = plays[i];}
            
            if(genreDict.ContainsKey(genres[i])){genreDict[genres[i]].Add(plays[i]);}
            else{genreDict[genres[i]] = new List<int>{plays[i]};}
            
        }
				// 전체 노래 개수 고려해서 정렬해놓은 딕셔너리
        var orderDict = totalPlayDict.OrderByDescending(x => x.Value);
        foreach(KeyValuePair<string,int> dict in orderDict)
        {
            var songList = genreDict[dict.Key];
            songList.Sort();
            songList.Reverse();
            int total = 0;
            for(int i = 0; i < songList.Count; i++)
            {
                if(i == 2){break;}
                if(originDict[songList[i]].Count > 1)
                {
                    for(int j = 0; j < originDict[songList[i]].Count; j++)
                    {
                        if(total == 2) {break;}
                        if(genres[originDict[songList[i]][j]] == dict.Key)
                        {
                            answer.Add(originDict[songList[i]][j]);
                            total += 1;
                        }
                    }
                }
                else
                {
                    answer.Add(originDict[songList[i]][0]);
                    total += 1;
                }
            }
            
        }

        return answer.ToArray();
    }
}