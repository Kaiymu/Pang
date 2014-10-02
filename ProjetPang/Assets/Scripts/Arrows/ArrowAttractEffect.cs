using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/************************************************************************************************
* On the arrow GameObject
** Allow to attract every orb on his way
************************************************************************************************/

public class ArrowAttractEffect : MonoBehaviour {

	public float strengthOfAttraction = 5.0f;
	public float maxGravityDistance = 4.0f;
	public float attractForce = 10.0f;

	private List<GameObject> _attractedFrom;
	private float _distance;
	private float _gravityAttract;
	private Vector2 _differencePlayerOrb;

	private ManagerArray _managerArray;

	void OnEnable()
	{
		_managerArray = GameObject.FindGameObjectWithTag("Manager").GetComponent<ManagerArray>();
		//_attractedFrom = _managerArray.getOrbArray();
	}

	// Attach automaticly to the ball if it's getting instantiated.
	void FixedUpdate()
	{
		foreach(GameObject orbBall in _attractedFrom)
		{
			_distance = Vector2.Distance(orbBall.transform.position, transform.position);

			// Calculating the distance between the shooted ball and the spikked balls.
			if(_distance <= maxGravityDistance)
			{
				_differencePlayerOrb = orbBall.transform.position - transform.position;
				_gravityAttract = _distance / maxGravityDistance;

				// If if put _differencePlayerOrb in negative, it repulse the balls, good to know.
				orbBall.rigidbody2D.AddForce(-_differencePlayerOrb.normalized * _gravityAttract * attractForce);
			}

		}
	}
}