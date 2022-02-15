using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 _direction = rb.velocity;

        float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Target")
        {
            rb.isKinematic = true;
            rb.velocity = Vector2.zero;
            transform.SetParent(other.gameObject.transform);
        }
    }
}
