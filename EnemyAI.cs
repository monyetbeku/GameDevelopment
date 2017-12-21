using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {
	private Rigidbody2D rbody;
	[Header("PathPoint")]
	public GameObject[] pathpoint;
	[Header("Enemy Status")]
	public float speed;
	public int targetpoint;

	// Use this for initialization
	void Start () {
		rbody = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		MovetoPoint ();
	}
	void MovetoPoint()
	{
		if (transform.position != pathpoint[targetpoint].transform.position)
		{
			transform.position = Vector2.MoveTowards (transform.position,new Vector2(pathpoint[targetpoint].transform.position.x,transform.position.y),speed * Time.deltaTime);
			if (transform.position.x == pathpoint[targetpoint].transform.position.x)
			{
				targetpoint++;
				if (targetpoint > 1)
				{
					targetpoint = 0;
				}
			}
		}
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		foreach(GameObject o in pathpoint)
		{
			Gizmos.DrawWireSphere (o.transform.position,0.5f);
		}
		Gizmos.DrawLine (pathpoint[0].transform.position,pathpoint[1].transform.position);
	}
}
