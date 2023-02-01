using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    public float speed = 5.0f;
    public Camera MainCamera;
    public GameObject Ghost;
    public bool GhostSight = false;
    
    
    public bool LastRoomHint = false;
    public bool MainItemHint = false;
    public bool ClassRoomHint = false;

    public static Controll instance;
    void Start()
    {
        if (instance == null)
            instance = this;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (GhostSight)
                GhostSight = false;
            else
                GhostSight = true;
        }

        if (GhostSight)
            Ghost.SetActive(true);
        else
            Ghost.SetActive(false);
    }

    private void Move()
    {
        Vector3 MoveDirection = Vector3.zero;
        


        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-2.3f,1.7f , 1);
            MoveDirection = new Vector3
                (
                -1,
                Input.GetAxisRaw("Vertical"),
                0
                );
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(2.3f, 1.7f, 1);
            MoveDirection = new Vector3
                (
                1,
                Input.GetAxisRaw("Vertical"),
                0
                );
        }

        else
        {
            MoveDirection = new Vector3
                           (
                           0,
                           Input.GetAxisRaw("Vertical"),
                           0
                           );
        }

        transform.position += MoveDirection * speed * Time.deltaTime;
        anim.SetBool("isRun", MoveDirection != Vector3.zero);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Next Portal"))
        {
            transform.position = new Vector3(-112, transform.position.y, 0);
        }

        else if (collision.CompareTag("Prev Portal"))
        {
            transform.position = new Vector3(60, transform.position.y, 0);
        }

       else if(collision.CompareTag("Main Item"))
        {
            if (MainItemHint)
                Debug.Log("휠체어 획득");
            else
                Debug.Log("아직 휠체어를 가져갈 수 없습니다.");
        }

        else if(collision.CompareTag("Finish"))
        {
            if (LastRoomHint)
                Debug.Log("문열기");
            else
                Debug.Log("비밀번호가 필요합니다.");
        }
    }
}
