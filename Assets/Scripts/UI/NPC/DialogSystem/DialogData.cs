using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogData
{
    public Dictionary<string, int> Data;

    public DialogData (Dictionary<string, int> data)
    {
        Debug.Log(data["ī��"]);
        if (data == null) Debug.Log("���̾�α� ������ �ȵ�");
        this.Data = data;
    }

}
