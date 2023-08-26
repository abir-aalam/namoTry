using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject Player;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCursor();
        Swim();
        UseHands();
        //RotateBody();
        if (rb.velocity.magnitude <= 2f)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);
        }
    }

    [SerializeField] float RotateSpeed = 15f;
    Vector3 lookdirection;

    void LookAtCursor()
    {
        if (rb.velocity.magnitude <= 0)
        {
            LeftArmTarget.parent.GetComponent<TwoBoneIKConstraint>().weight = 0f;
            RightArmTarget.parent.GetComponent<TwoBoneIKConstraint>().weight = 0f;
            if (Player.GetComponent<Animator>().GetInteger("Swim") == 1)
            {
                Player.GetComponent<Animator>().SetInteger("Swim", -1);
            }
            

        }
        else
        {
            //Quaternion rotation = Quaternion.EulerAngles(-2.373f, 71.016f, 86.997f);
            // Player.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);
            LeftArmTarget.parent.GetComponent<TwoBoneIKConstraint>().weight = 1f;
            RightArmTarget.parent.GetComponent<TwoBoneIKConstraint>().weight = 1f;
            Player.GetComponent<Animator>().SetInteger("Swim", 1);
        }
    }

    float SpeedMultiplier = 2;
    float acceleration = 0.5f;
    float decceleration = 1f;

    Vector3 InitialMousePos;

    Vector3 mouseVelocity;

    float speed;

    bool SwimStarted;


    [SerializeField] Transform LeftArmTarget, RightArmTarget;
    void Swim()
    {
        Camera.main.transform.position = transform.position - Vector3.forward * 5;

        if (Input.GetMouseButtonDown(0))
        {
            SwimStarted = true;
            InitialMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lookdirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            speed = SpeedMultiplier;

            
        }
        else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            SwimStarted = false;
            Vector3 LeftV = new Vector3(0,-1f,0);
            Vector3 RightV = new Vector3(0,1f,0);
            LeftArmTarget.localPosition = LeftV;
            RightArmTarget.localPosition = RightV;
        }

        if (SwimStarted)
        {
            if (Input.GetMouseButton(0))
            {
                if ((InitialMousePos - Camera.main.ScreenToWorldPoint(Input.mousePosition)).magnitude < 5f)
                {
                       Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                       float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                       Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                       transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotateSpeed * Time.deltaTime);
                    //transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);

                    mouseVelocity = (InitialMousePos - Camera.main.ScreenToWorldPoint(Input.mousePosition)) / Time.deltaTime;

                   LeftArmTarget.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.right * 0.1f ;
                   RightArmTarget.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.right * 0.1f;
                }
            }
        }
        else
        {
            if (speed > 0)
            {
                speed -= decceleration * Time.deltaTime;
            }
            else if (speed < 0)
            {
                speed = 0;
            }
             
        }


        rb.velocity = mouseVelocity * speed * Time.deltaTime;
    }

    float zrot;

    Quaternion rot;

    void RotateBody()
    {
        

        if (!Input.GetMouseButton(0) || !Input.GetMouseButton(1))
        {
            if (Input.GetKey(KeyCode.A))
            {
                zrot += RotateSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + 50 * Time.deltaTime));
            }

            if (Input.GetKey(KeyCode.D))
            {
                zrot -= RotateSpeed * Time.deltaTime;
                transform.rotation = Quaternion.EulerRotation(new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z + (zrot * Mathf.PI / 180)));
            }
        }
        else
        {

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(Vector3.forward, lookdirection), RotateSpeed * Time.deltaTime);
        }
    }

    void UseHands()
    {
        if (Input.GetMouseButton(0))
        {
            LeftArmTarget.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.right * 0.1f;
        }

        if (Input.GetMouseButton(0))
        {
            RightArmTarget.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + transform.right * 0.1f;
        }
    }
}
