using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(BoxCollider2D))]
[RequireComponent (typeof(Animator))]
public class PinNormal : PinAbstract, ICollidable {

    [SerializeField] private float m_pinSpeed = 1;

    private Rigidbody2D m_rigidbody;
    private Animator m_animator;

    // Use this for initialization
    void Start () {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_isAttached = false;
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (!m_isAttached) {
            ICollidable collidable = collision.gameObject.GetComponent<ICollidable>();
            if (collidable != null) {
                m_isAttached = !m_isAttached;
                m_rigidbody.Sleep();
                collidable.HandleCollision(gameObject);
            }
        }
    }

    void ICollidable.HandleCollision(GameObject obj) {
        // End game cause a pin collided with it
        print("End game");
    }

    public override void LaunchPin() {
        m_animator.SetTrigger("pinLaunch");
        m_rigidbody.velocity = Vector2.up * m_pinSpeed;
    }

    
}
