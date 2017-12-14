using UnityEngine;
using System.Collections;

public class DoorOpener : MonoBehaviour {
	public float direction;
	public float speed = 500.0f;
	private bool doorsOpening;
	private bool doorsClosing;

	private Vector3 BottomCorner;
	private Vector3 StartRot;
	private Vector3 EndRot;

	void Start () {
		doorsOpening = true;    
		Mesh mesh = GetComponent<MeshFilter>().mesh;
		Bounds boundary = mesh.bounds;
		BottomCorner = new Vector3(boundary.size.x * this.transform.localScale.x/2,boundary.size.y * this.transform.localScale.y/2,boundary.size.z * this.transform.localScale.z/2);

		Vector3 r = BottomCorner.x * this.transform.right;
		Vector3 u = BottomCorner.y * this.transform.up;
		Vector3 f = BottomCorner.z * this.transform.forward;

		BottomCorner = this.transform.position +  r + u + f;

		StartRot = this.transform.right;
		EndRot = Vector3.Cross (-1*direction*this.transform.right,this.transform.up);

	}

	void Update () {

		if (doorsOpening && (this.transform.right - EndRot).magnitude > 0.1) {
			this.transform.RotateAround(BottomCorner, this.transform.up, speed * direction * Time.deltaTime);
		}
		if (doorsClosing && (this.transform.right - StartRot).magnitude > 0.1){
			this.transform.RotateAround(BottomCorner, this.transform.up, speed * direction * -1 * Time.deltaTime);
		}
	}
}