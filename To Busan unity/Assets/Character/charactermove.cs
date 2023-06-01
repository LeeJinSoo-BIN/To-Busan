using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class charactermove : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3f;
    public bool isMoveable = true;
    public Animator animator;
    public float zoom = 2;
    public Button Button_find;
    //public int  PlayerSetting=0;

    public float count = 0.0f;
    public float longclick_time = 0.3f;
    public GameObject foundChest;


    void Start()
    {
        animator = GetComponent<Animator>();

        Camera cam = Camera.main;
        cam.transform.SetParent(transform);
        cam.transform.localPosition = new Vector3(0f, 0f, -1f);
        cam.orthographicSize = zoom;


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
            {
                bool isMove = false;
                Vector3 currentScale = transform.localScale;


                if (Input.GetMouseButton(0))
                {
                    count += Time.deltaTime;
                    if (count > longclick_time)
                    {
                        Vector3 dir = (Input.mousePosition - new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0f)).normalized;

                        if (dir.x < 0f)
                        {
                            if (currentScale.x > 0)
                                currentScale.x *= -1;
                        }
                        else if (dir.x > 0f)
                        {
                            if (currentScale.x < 0)
                                currentScale.x *= -1;
                        }
                        transform.localScale = currentScale;
                        transform.position += dir * speed * Time.deltaTime;
                        isMove = dir.magnitude != 0f;
                    }



                }

                else
                {
                    Vector3 dir = Vector3.ClampMagnitude(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f), 5f);
                    if (dir.x < 0f)
                    {
                        if (currentScale.x > 0)
                            currentScale.x *= -1;
                    }
                    else if (dir.x > 0f)
                    {
                        if (currentScale.x < 0)
                            currentScale.x *= -1;
                    }
                    transform.localScale = currentScale;
                    transform.position += dir * speed * Time.deltaTime;
                    isMove = dir.magnitude != 0f;

                }



                animator.SetBool("isWalking", isMove);

                if (Input.GetMouseButtonUp(0))
                {
                    count = 0.0f;
                }

            }

        }
        else animator.SetBool("isWalking", false);
    }




    void OnTriggerStay2D(Collider2D collider)
    {
        foundChest = collider.gameObject;
        if (foundChest.layer == 8)
        {
            Button_find.interactable = true;

        }

    }
    void OnTriggerExit2D(Collider2D collider)
    {
        Button_find.interactable = false;
    }



}