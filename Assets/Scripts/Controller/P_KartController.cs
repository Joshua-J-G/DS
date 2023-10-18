using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class P_KartController : MonoBehaviour
{
    public Transform kartModel;
    public Transform kartNormal;
    public Rigidbody Sphere;

    public LayerMask layerMask;

    [SerializeField] float Gravity = 9.81f;

    [Header("Model Parts")]

    public Transform frontWheels;
    public Transform backWheels;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }

    // Update is called once per frame
    void Update()
    {


      transform.position = Sphere.transform.position - new Vector3(0,0.4f,0);

        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }

        //b) Wheels
        frontWheels.localEulerAngles = new Vector3(frontWheels.localEulerAngles.x, (Input.GetAxis("Horizontal") * 15), 0);
     frontWheels.localEulerAngles += new Vector3(Sphere.velocity.magnitude / 2, 0, 0);
     backWheels.localEulerAngles += new Vector3(Sphere.velocity.magnitude / 2, 0, 0);


    }

  

    private void FixedUpdate()
    {

        Sphere.AddForce(Vector3.down * Gravity, ForceMode.Acceleration);



        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitOn, 1.1f, layerMask);
        Physics.Raycast(transform.position + (transform.up * .1f), Vector3.down, out hitNear, 2.0f, layerMask);

        //Normal Rotation
        kartNormal.up = Vector3.Lerp(kartNormal.up, hitNear.normal, Time.deltaTime * 8.0f);
        kartNormal.Rotate(0, transform.eulerAngles.y, 0);

    }


}
