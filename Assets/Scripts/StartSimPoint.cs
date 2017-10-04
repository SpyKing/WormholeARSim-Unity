using UnityEngine;
using System.Collections;

public class StartSimPoint : MonoBehaviour
{
	public StartSim startSim;

	void Start() {
		startSim = GameObject.FindWithTag ("GameController").GetComponent<StartSim> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			startSim.transport ();
		}
	}
}

