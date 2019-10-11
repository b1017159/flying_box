using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OVRInputTest : MonoBehaviour {
	// Start is called before the first frame update
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		OVRInput.Update();

		if(OVRInput.GetDown(OVRInput.RawButton.A))
			Debug.Log("A Pushed");
		if(OVRInput.GetDown(OVRInput.RawButton.B))
			Debug.Log("B Pushed");
		if(OVRInput.GetDown(OVRInput.RawButton.X))
			Debug.Log("X Pushed");
		if(OVRInput.GetDown(OVRInput.RawButton.Y))
			Debug.Log("Y Pushed");
	}
}
