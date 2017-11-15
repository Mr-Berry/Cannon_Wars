using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody m_rb;
	public float m_speed;
	public float m_angularSpeed;
	private bool m_isMoving = false;

	private void Start() {
		m_rb = GetComponent<Rigidbody>();
	}

	private void Update() {
		HandleInput();
	}

	private void HandleInput() {
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");
		if (x > z && !m_isMoving) {
			m_rb.angularVelocity = new Vector3(x*m_speed,0,0);
		} else if (z > x && !m_isMoving) {

		}
		if (m_isMoving) {
			if (m_rb.velocity.x > 0) {

			}
		}
//		m_rb.velocity = new Vector3(x * m_speed,m_rb.velocity.y,z * m_speed);
//		transform.Rotate(z*m_angularSpeed,0,x*-m_angularSpeed);
	}
}
