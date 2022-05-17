using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissonsInteract : MonoBehaviour
{
    [SerializeField] protected GpsLocalizador _gps;
    [SerializeField] CarControler2 _car;
    [SerializeField] protected GameObject _stop;
    [SerializeField] protected GameObject _space;

    bool _isInside = false;
    protected bool _isReady = false;
    // Start is called before the first frame update
    void Start()
    {
        _stop.SetActive(false);
        _space.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        SapceSign();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        CarControler2 car = other.gameObject.GetComponent<CarControler2>();
        if (car != null)
        {
            _isInside = true;
            _stop.SetActive(true);
        }

    }
    protected virtual void OnTriggerExit(Collider other)
    {
        CarControler2 car = other.gameObject.GetComponent<CarControler2>();
        if (car != null)
        {
            _isInside = false;
            _stop.SetActive(false);
        }
    }

    protected virtual void SapceSign()
    {
        if(_isInside == true && _car.RealSpeed < 1.5f)
        {
            _stop.SetActive(false);
            _space.SetActive(true);
            _isReady = true;
        }
        else if(_isInside == false || _car.RealSpeed > 1.5f)
        {
            _space.SetActive(false);
            _isReady = false;
        }
    }

}
