using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollows : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] CarControler car;
    [SerializeField] float smoothing;
    void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

    }
    private void FixedUpdate()
    {
        //if (car.MoveInput > 0)
        //{
        //    transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z + 4);
        //}
        //else if (car.MoveInput < 0)
        //{
        //    transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z- 4);
        //}
        //else
        //{
        //    transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);

        //}
    }

}
