using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackGroundUI : MonoBehaviour
{
    float time;


    private void Update()
    {
        if (time < 0.5f)
        {
            GetComponent<Text>().color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            GetComponent<Text>().color = new Color(1, 1, 1,time);

            if (time > 1f)
                   time = 0;
        }
        time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            Loading.Instance.LoadScene("Test");
      //      SceneChange();
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Test");
    }

}
