/*
 * Oceane Peretti - K1844498 - 3D Games programming Assignment 2
 * I confirm that this project is a product of my own and not the one of someone else.
 */
using UnityEngine;

public class rotation : MonoBehaviour {
	public float xRotation = 0F;
	public float yRotation = 0F;
	public float zRotation = 0F;
	void Start(){
		InvokeRepeating("rotate", 0f, 0.0167f);
	}
	void OnDisable(){
		CancelInvoke();
	}
	public void clickOn(){
		InvokeRepeating("rotate", 0f, 0.0167f);
	}
	public void clickOff(){
		CancelInvoke();
	}
	void rotate(){
		this.transform.localEulerAngles += new Vector3(xRotation,yRotation,zRotation);
	}
}
