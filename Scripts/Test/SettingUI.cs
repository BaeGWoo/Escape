using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingUI : MonoBehaviour
{
        

    private Animator anim;
    public GameObject main;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    public void isOpen()
    {
        main.SetActive(!main.activeSelf);
    }

    public void Close()
    {
        StartCoroutine(CloseAfterDelay());   
    }

    private IEnumerator CloseAfterDelay()
    {
        anim.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        anim.ResetTrigger("close");
    }

    
}
