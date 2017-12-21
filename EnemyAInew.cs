using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAInew : MonoBehaviour {

	private Vector3 posA;
	private Vector3 posB;
	public float speed;
	public Transform current;
	public Transform destination;


	void Start () {
		posA = current.localPosition;
		posB = destination.localPosition;
	}
	
	void Update () {
		current.localPosition = Vector3.MoveTowards (current.localPosition, destination.localPosition, speed * Time.deltaTime);
		if (current.localPosition == destination.localPosition) {
			destination.localPosition = destination.localPosition != posA ? posA : posB;
		}
	}

}
