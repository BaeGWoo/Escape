using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad : MonoBehaviour
{
    [SerializeField] private Text pad;
    public GameObject gameObj;
    private string Answer = "12345";

    public void Number(int number)
    { 
        pad.text += number.ToString();
    }

    public void Enter()
    {
        if (pad.text == Answer)
        {
            pad.text = "GOOD";
            StartCoroutine("Pass");
        }

        else
        { 
            pad.text = "ERROR";
        }
    }

    IEnumerator Pass()
    {
        yield return new WaitForSeconds(1);
        gameObj.SetActive(false);
    }


}
