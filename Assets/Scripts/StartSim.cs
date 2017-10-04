using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSim : MonoBehaviour {

	public bool startSim = false;
	public bool accelerate = false;
	public bool constant = false;
	public int shipSpeed = 10;
	public Transform startSimPoint;
	public Transform endSimPoint;
	public GameObject ship;
	public Rigidbody shipRb;
	public Vector3 v;
	// Use this for initialization
	void Awake () {
		ship = GameObject.FindWithTag ("Player");
		shipRb = ship.GetComponent<Rigidbody>();
		v = new Vector3(shipSpeed, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.touchCount > 0 && Input.touches[0].tapCount >= 1) || (Input.GetKey(KeyCode.Space))) {
			ship.transform.position = startSimPoint.position;
			startSim = true;
			accelerate = true;
		}

		if (startSim) {
			//increase the velocity of the ship until it enters trigger
			//then quickly transport to other transform it and quickly decrease speed
			if (accelerate) {
				v -= new Vector3 (shipSpeed, 0, 0);
			} else if (constant) {
				v = new Vector3 (-shipSpeed * Time.deltaTime, 0, 0);
			} else {
				v = Vector3.zero;
			}

			if (v.Equals(Vector3.zero)) {
				startSim = false;
			}

			shipRb.AddForce (v);
		}
	}

	public void transport() {
		ship.transform.position = endSimPoint.position;
		accelerate = false;
		constant = true;
	}

	public void endSim() {
		shipRb.velocity = Vector3.zero;
		constant = false;
		v = Vector3.zero;
	}
}
