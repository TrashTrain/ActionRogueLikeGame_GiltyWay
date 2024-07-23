using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDoorMove : MonoBehaviour
{
    public static LoadDoorMove Instance;
    public Animator doorMove;

    private void Awake()
    {
        Instance = this;
    }
    private IEnumerator CloseDoor(GameObject setPanel, bool isShow)
    {
        yield return StartCoroutine(MoveDoorAni(true));

        if(isShow) setPanel.gameObject.SetActive(true);
        else setPanel.gameObject.SetActive(false);

        yield return StartCoroutine(MoveDoorAni(false));

    }

    private IEnumerator MoveDoorAni(bool doorClose)
    {
        Debug.Log("in");
        if (doorClose)
        {
            Debug.Log("true");
            doorMove.Play("DoorClose");
            yield return new WaitForSeconds(1f);
        }
        else
        {
            Debug.Log("false");
            doorMove.Play("DoorOpen");
        }
        yield return null;
    }

    public void OnClickSetLoadPanel(GameObject setPanel, bool isShow)
    {
        StartCoroutine(CloseDoor(setPanel, isShow));

    }

}
