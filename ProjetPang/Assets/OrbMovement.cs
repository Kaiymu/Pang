using UnityEngine;
using System.Collections;

public class OrbMovement : LegacyOrbMovement {

	protected override void OnEnable () {
		base.OnEnable();
	}
	
	public override void MovementWall(string nameWall){
		base.MovementWall(nameWall);
	}
}
