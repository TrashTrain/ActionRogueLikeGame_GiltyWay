using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData
{
    public Dictionary<string, int> Data;

    public DialogData (Dictionary<string, int> data)
    {
        Debug.Log(data["카도"]);
        if (data == null) Debug.Log("다이얼로그 데이터 안들어감");
        this.Data = data;
    }

}
