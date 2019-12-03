/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;
using UnityEngine.Audio;
public class settingsMenu : MonoBehaviour
{
	public AudioMixer audioMix;
 public void SetVolume(float volume)
	{
        Debug.Log(volume);
        audioMix.SetFloat("volume", volume);
	}
    public void setDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }


}
