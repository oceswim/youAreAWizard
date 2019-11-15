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


    private float lastClickTime;
    private int single;
    private float wait;

    //private int firstShield = 0;
    //public static bool ShieldActive;
    public static bool active;
    //private Vector3 position;
    private bool doubleTrigger, singleTrigger;
    private int triggerCount;
    private float timerBetweentrigger, firstCickTime;

    private bool doubleClick, singleClick;
    private int clickCount;
    private float timerBetweenClick, firstClick;

    //test
    public GameObject ObjectToRotate;
    Vector3 objRotation;
    public float objRotationSpeed = 60f;
    private Vector2 trackpadX;

    //
    private bool  protection;

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

        firstClick = 0f;
        timerBetweenClick = .3f;
        clickCount = 0;
        doubleClick = true;
        singleClick = false;

        objRotation = new Vector3(0f, 0f, 0f);


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
            if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
            {
                clickCount += 1;
            }
            else if (m_isWand && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                triggerCount += 1;
            }
            if(clickCount==1 &&doubleClick)
            {
                firstClick = Time.time;
                StartCoroutine(DoubleClickDetect());
            }
            else if (triggerCount == 1 && doubleTrigger)
            {
                firstCickTime = Time.time;
                StartCoroutine(DoubleTriggerDetect());
            }
            if(!m_isWand)
            {
                //teleport/rotate cam here
            }
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
                Shield.SetActive(true);
                active = true;
            }
            else
            {
                Shield.SetActive(false);
                active = false;
            }

            //double trigger switch apparel

        }
        single = 0;
        triggerCount = 0;
        firstCickTime = 0f;
        doubleTrigger = true;
        singleTrigger = false;

    }
    bool TouchPadTouched
    {
        get
        {
            return OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
        }
    }

    private IEnumerator DoubleClickDetect()
    {
        doubleClick = false;
        while (Time.time < firstClick + timerBetweenClick)
        {
            if (clickCount == 2)
            {
               
                singleClick = false;
                break;
            }
            singleClick = true;
            yield return new WaitForEndOfFrame();
        }
        if (!singleClick)
        {
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

           

        }
  
        clickCount = 0;
        firstClick = 0f;
        doubleClick = true;
        singleClick = false;

    }
    



}


