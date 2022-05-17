using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 50, _drag = 0.98F,_maxSpeed = 50, _steerAngle = 20, _tracion = 1;
    Vector3 _moveForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //movimento
        _moveForce += transform.forward * _moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += _moveForce * Time.deltaTime;


        //Drag and max Speed
        _moveForce *= _drag;
        _moveForce = Vector3.ClampMagnitude(_moveForce, _maxSpeed);

        //steering
        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * _moveForce.magnitude * _steerAngle * Time.deltaTime);

        //tração
        _moveForce = Vector3.Lerp(_moveForce.normalized, transform.forward, _tracion * Time.deltaTime) * _moveForce.magnitude;

    }
}
