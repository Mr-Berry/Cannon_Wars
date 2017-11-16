using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody m_rb;
	public float m_speed;
	private bool m_isMoving = false;
	private Vector3 xRot = new Vector3(0,0,90f);
	private Vector3 zRot = new Vector3(90f,0,0);
	private Vector3 targetAngle;
	private Vector3 xMove = new Vector3(2,0,0);
	private Vector3 zMove = new Vector3(0,0,2);
	private Vector3 moveAmount;

	private void Start() {
		m_rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		HandleInput();
	}

	private void HandleInput() {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		if (Mathf.Abs(x) > Mathf.Abs(z) && !m_isMoving) {
			m_isMoving = true;
			if (x > 0) {
				targetAngle = -1*xRot;
				moveAmount = xMove;
			} else {
				targetAngle = xRot;
				moveAmount = -1*xMove;
			}
			StartCoroutine(Rotate(targetAngle,0.2f));
			StartCoroutine(Move(moveAmount,0.2f));
		} else if (Mathf.Abs(z) > Mathf.Abs(x) && !m_isMoving) {
			m_isMoving = true;
			if (z > 0) {
				targetAngle = zRot;
				moveAmount = zMove;
			} else {
				targetAngle = -1*zRot;
				moveAmount = -1*zMove;
			}
			StartCoroutine(Rotate(targetAngle,0.2f));
			StartCoroutine(Move(moveAmount,0.2f));
		}
	}

	IEnumerator Rotate(Vector3 byAngles, float time) {
		Quaternion fromAngle = transform.rotation ;
		Quaternion toAngle = Quaternion.Euler(transform.eulerAngles + byAngles) ;
		for(float t = 0f ; t < 1f ; t += Time.deltaTime/time) {
			transform.rotation = Quaternion.Lerp(fromAngle, toAngle, t) ;
			yield return null ;
		}
		transform.rotation = Quaternion.identity;
		m_isMoving = false;
	}

	IEnumerator Move(Vector3 byAmount, float time) {
		Vector3 fromPos = transform.position;
		Vector3 toPos = transform.position + byAmount;
		for(float t = 0f ; t < 1f ; t += Time.deltaTime/time) {
			transform.position = Vector3.Lerp(fromPos, toPos, t) ;
			yield return null ;
		}		
	}
}
