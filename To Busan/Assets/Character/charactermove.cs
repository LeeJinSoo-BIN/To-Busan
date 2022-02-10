using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 10000000f;
    public bool isMoveable = true;
    public Animator animator;
    //public int  PlayerSetting=0;

    void Start()
    {
        animator = GetComponent<Animator>();
        // if (hasAuthority)
        // {
        Camera cam = Camera.main;
        cam.transform.SetParent(transform);
        cam.transform.localPosition = new Vector3(0f, 0f, -1f);
        cam.orthographicSize = 5;
        // }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }


    public void Move()
    {

        if (isMoveable)
        {
            bool isMove = false;

            {
                Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 5f);
                if (dir.x < 0f) transform.localScale = new Vector3(-1f, 1f, 1f);
                else if (dir.x > 0f) transform.localScale = new Vector3(1f, 1f, 1f);
                transform.position += dir * speed * Time.deltaTime;
                isMove = dir.magnitude != 0f;

            }

            {
                if (Input.GetMouseButton(0))
                {
                    Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;

                    if (dir.x < 0f) transform.localScale = new Vector3(-1f, 1f, 1f);
                    else if (dir.x > 0f) transform.localScale = new Vector3(1f, 1f, 1f);
                    transform.position += dir * speed * Time.deltaTime;
                    isMove = dir.magnitude != 0f;

                }
            }
            animator.SetBool("isWalking", isMove);



        }


    }
}