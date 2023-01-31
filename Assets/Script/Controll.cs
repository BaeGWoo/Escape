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
            transform.rotation = Quaternion.Euler(0, 180, 0);
            MoveDirection = new Vector3
                (
                -1,
                Input.GetAxisRaw("Vertical"),
                0
                );
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
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
            transform.position = new Vector3(-88, transform.position.y, 0);
        }

        else if (collision.CompareTag("Prev Portal"))
        {
            transform.position = new Vector3(92, transform.position.y, 0);
        }

        else if (collision.CompareTag("Enter Door"))
        {
            transform.position = new Vector3
                (
                transform.position.x,
                transform.position.y + 28,
                0
                );
            
        }

        else if (collision.CompareTag("Exit Door"))
        {
            transform.position = new Vector3
                           (
                           transform.position.x,
                           transform.position.y - 28,
                           0
                           );
        }
    }
}
