using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    [SerializeField] private GameObject _arrowPref;
    [SerializeField] private float _speed;
    private Vector2 _direction;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 _bowPos = transform.position;

        _direction = _mousePos - _bowPos;
        transform.right = _direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject _newArrow = Instantiate(_arrowPref, transform.position, transform.rotation);
        _newArrow.GetComponent<Rigidbody2D>().AddForce(transform.right * _speed);
    }
}
