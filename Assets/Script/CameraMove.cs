using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //108>y>40
        //72>x>-69


        //72 15 -43 -68
        //72 26  -20  -68
        //1. 캐릭터와 같이 움직이는 카메라

        #region
        if (transform.position.x <= -69)
            transform.position = new Vector3(-69, transform.position.y, -10);
        if (transform.position.x >= 72)
        {
            transform.position = new Vector3(72, transform.position.y, -10);
        }
        if (transform.position.y >= 108)
        {
            transform.position = new Vector3(transform.position.x, 108, -10);
        }
        if (transform.position.y <= 40)
        {
            transform.position = new Vector3(transform.position.x,40, -10);
        }
            {
            Vector3 direction = new Vector3
                (
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"),
                0
                );
            transform.position += direction * speed * Time.deltaTime;
        }
        #endregion

 

        //103  76
        //2. 캐릭터가 시야밖으로 나간다면 크게 움직이는 카메라
        /*
        if (Controll.instance.transform.position.x <= -47)
        {
            transform.position = new Vector3(-68, transform.position.y, -10);
            if (Controll.instance.transform.position.y < 56)
            {
                transform.position = new Vector3(transform.position.x, 46, -10);
            }

            if (Controll.instance.transform.position.y>56 && Controll.instance.transform.position.y<=86)
            {
                transform.position = new Vector3(transform.position.x, 76, -10);
            }

            if (Controll.instance.transform.position.y > 86)
            {
                transform.position = new Vector3(transform.position.x, 103, -10);
            }
        }

        if (Controll.instance.transform.position.x>=-47&& Controll.instance.transform.position.x < -2)
        {
            transform.position = new Vector3(-20, transform.position.y, -10);
        }

        if (Controll.instance.transform.position.x >= -2 && Controll.instance.transform.position.x < 44)
        {
            transform.position = new Vector3(26, transform.position.y, -10);
        }

        if (Controll.instance.transform.position.x >= 44)
        {
            transform.position = new Vector3(72, transform.position.y, -10);
        }
        */
    }
}
