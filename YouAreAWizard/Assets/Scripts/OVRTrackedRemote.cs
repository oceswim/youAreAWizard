/************************************************************************************

Copyright   :   Copyright 2017 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.4.1 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

https://developer.oculus.com/licenses/sdk-3.4.1


Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

 ************************************************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VR;

/// <summary>
/// Simple helper script that conditionally enables rendering of a controller if it is connected.
/// </summary>
public class OVRTrackedRemote : MonoBehaviour
{
    public GameObject Shield;

    /// <summary>
    /// The root GameObject that represents the GearVr Controller model.
    /// </summary>
    public GameObject m_Wand;

    /// <summary>
    /// The root GameObject that represents the Oculus Go Controller model.
    /// </summary>
    public GameObject m_Orb;

    /// <summary>
    /// The controller that determines whether or not to enable rendering of the controller model.
    /// </summary>
    public OVRInput.Controller m_controller;

    public static bool m_isWand;
    private bool m_prevControllerConnected;
    private bool m_prevControllerConnectedCached;

    private spawnRay mSpawnRay;


    private readonly float doubleClickTimeLimit = 0.3f;


    private float lastClickTime;
    private int single;

    //private int firstShield = 0;
    //public static bool ShieldActive;
    public static bool active;
    //private Vector3 position;
    private bool doubleTrigger, singleTrigger;
    private int triggerCount;
    private float timerBetweentrigger, firstCickTime;

    private bool  protection;

    Vector3 ObjRotation = new Vector3(0f, 0f, 0f);
    public float objRotationSpeed = 60f;
    private Vector2 touchpad;




    void Start()
    {
        //ShieldActive = false;
        //teleportation = false;
        //position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        m_isWand = true;
        firstCickTime = 0f;
        timerBetweentrigger = .3f;
        triggerCount = 0;
        doubleTrigger = true;
        singleTrigger = false;
        active = false;
        single = 0;
    }

    private void Awake()
    {
        mSpawnRay = GetComponentInChildren<spawnRay>();
    }
    public void Update()
    {


        bool controllerConnected = OVRInput.IsControllerConnected(m_controller);

        if ((controllerConnected != m_prevControllerConnected) || !m_prevControllerConnectedCached)
        {
            m_Wand.SetActive(controllerConnected);

            m_prevControllerConnected = controllerConnected;
            m_prevControllerConnectedCached = true;
        }

        if (!controllerConnected)
        {
            return;
        }
        else
        {
            rotateCamera.Controller = m_controller;
            if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
            {
                float timeSinceClicked = Time.time - lastClickTime;
                if (timeSinceClicked <= doubleClickTimeLimit)
                {
                    //if wand not active play wand noise and switch to wand
                    if (m_isWand)
                    {
                        //play orb noise

                        Shield.SetActive(false);
                        m_isWand = false;
                        m_Wand.SetActive(false);
                        m_Orb.SetActive(true);
                        // Time.timeScale = 0.5f;

                    }
                    else if (!m_isWand)
                    {
                        //play wand noise
                        // Time.timeScale = 1.0f;
                        m_isWand = true;
                        m_Wand.SetActive(true);
                        m_Orb.SetActive(false);
                    }
                    //else if wand active play orb noise and switch to wand
                    //double clicker
                }
        

                lastClickTime = Time.time;
            }
            else if (m_isWand && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                triggerCount += 1;
            }
            if(!m_isWand)
            {
                if (TouchPadTouched)
                {
                    touchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
                    var xAxis = touchpad.x;
                    ObjRotation.y += xAxis * Time.deltaTime * objRotationSpeed;
                    transform.rotation = Quaternion.Euler(ObjRotation);
                }
            }

            if (triggerCount == 1 && doubleTrigger)
            {
                firstCickTime = Time.time;
                StartCoroutine(DoubleTriggerDetect());
            }
        }
    }
    bool TouchPadTouched
    {
        get
        {
            return OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
        }
    }
    private IEnumerator DoubleTriggerDetect()
    {
        doubleTrigger = false;
        while (Time.time < firstCickTime + timerBetweentrigger)
        {
            if (triggerCount == 2)
            {

                singleTrigger = false;
                break;
            }
            singleTrigger = true;
            yield return new WaitForEndOfFrame();
        }
        if (singleTrigger)
        {

            if (!active && single == 0)
            {
                single++;
                mSpawnRay.CastSpell();
            }

        }
        else
        {

            if (!active)
            {
               /* if (firstShield == 0)
                {
                    ShieldActive = true;
                    firstShield++;
                }
                if (firstShield == 1)
                {
                    ShieldActive = false;
                }*/
                Shield.SetActive(true);
                active = true;
            }
            else
            {
                Shield.SetActive(false);
                active = false;
            }


        }
        single = 0;
        triggerCount = 0;
        firstCickTime = 0f;
        doubleTrigger = true;
        singleTrigger = false;

    }

    /*Vector3 SwipeDir
    {
        get
        {
            Vector2 touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            Vector3 forward1 = new Vector3(touch.x, 0.0f, touch.y).normalized;
            forward1 = Vector3.ProjectOnPlane(forward1, Vector3.up);
            return forward1.normalized;

        }
    }*/



}


