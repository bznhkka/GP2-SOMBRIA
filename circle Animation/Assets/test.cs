using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(target.transform.position, Vector3.down, 20 * Time.deltaTime);
            //gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * 10f);
        }
    }
}
