using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    void GenerateData()
    {
        // 배치물은 100번대, 대화가능한 npc 는 1000대부터
        talkData.Add(1000, new string[] { "안녕? 처음보는 얼굴이네.", "우리 마을에 온 걸 환영해." });
        talkData.Add(100, new string[] { "별 볼일없는 쓸모없는 통이다." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
        {
            return null;
        }
        else
            return talkData[id][talkIndex];
    }
}
