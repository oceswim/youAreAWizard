using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public static OVRInput.Controller Controller;
    Vector3 ObjRotation;
    public float objRotationSpeed = 60f;
    private Vector2 touchpad;
    // Update is called once per frame
    private void Start()
    {
        ObjRotation = transform.position;
    }
    private void Update()
    {
        if (TouchPadTouched && OVRInput.IsControllerConnected(Controller) && !OVRTrackedRemote.m_isWand)
        {
            touchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            var xAxis = touchpad.x;
            ObjRotation.y += xAxis * Time.deltaTime * objRotationSpeed;
            transform.rotation = Quaternion.Euler(ObjRotation);
        }
    }
    bool TouchPadTouched
    {
        get
        {
            return OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
        }
    }
    
}
