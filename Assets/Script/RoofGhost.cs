using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofGhost : MonoBehaviour
{
    public Animator anim;
    private float speed = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 MoveDirection = new Vector3(1,0,0);
        transform.position += MoveDirection * speed * Time.deltaTime;
        anim.SetBool("run", MoveDirection != Vector3.zero);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Next Portal"))
        {
            transform.position = new Vector3(-88, transform.position.y, 0);
        }
    }
}
