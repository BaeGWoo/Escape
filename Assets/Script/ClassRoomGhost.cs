using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoomGhost : MonoBehaviour
{
    public GameObject GhostPre;
    public GameObject ChageGhost;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Controll.instance.ClassRoomHint)
        {
            GhostPre.SetActive(false);
            ChageGhost.SetActive(true);
        }
    }
}
