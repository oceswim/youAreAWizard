using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testing : MonoBehaviour
{
    Vector3 ObjRotation;
    // Start is called before the first frame update
    void Start()
    {
        print(transform.position + " rot: " + transform.rotation);
        ObjRotation = GameObject.Find("/Player").transform.rotation.eulerAngles;
        print(ObjRotation);
        print(Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
