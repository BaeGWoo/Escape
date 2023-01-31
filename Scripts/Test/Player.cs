using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SettingUI settingUI;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            settingUI.isOpen();
 
    }


}
