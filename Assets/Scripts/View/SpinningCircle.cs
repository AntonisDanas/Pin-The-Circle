using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(CircleCollider2D))]
public class SpinningCircle : MonoBehaviour, ICollidable {

    // TODO change value based on the model of the level
    [SerializeField] private float m_rotationSpeed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(transform.position, Vector3.forward, m_rotationSpeed * Time.deltaTime);
    }

    void ICollidable.HandleCollision(GameObject obj) {
        obj.transform.SetParent(transform);
    }
}
