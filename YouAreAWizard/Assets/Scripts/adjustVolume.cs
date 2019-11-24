using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adjustVolume : MonoBehaviour
{
	public Transform target;
    private AudioSource theClip;
	void Start()
	{
        theClip = transform.GetComponent<AudioSource>();
		

	}
    private void Update()
    {

        if (theClip.isPlaying)
        { // do this only if some audio is being played in this gameObject's AudioSource

            float distanceToTarget = Vector3.Distance(transform.position, target.position); // Assuming that the target is the player or the audio listener

            if (distanceToTarget < 1) { distanceToTarget = 1; }

            theClip.volume = 1 / distanceToTarget; // this works as a linear function, while the 3D sound works like a logarithmic function, so the effect will be a little different (correct me if I'm wrong)

            // this will adjust the volume based on distance every 1 second (Obviously, You can reduce this to a lower value if you want more updates per second)

        }
    }
}
