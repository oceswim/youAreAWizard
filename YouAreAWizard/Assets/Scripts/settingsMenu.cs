using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class settingsMenu : MonoBehaviour
{
	public AudioMixer audioMix;
    // Start is called before the first frame update
 public void SetVolume(float volume)
	{
        audioMix.SetFloat("volume", volume);
	}
    public void setDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }


}
