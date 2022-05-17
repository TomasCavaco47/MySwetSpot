
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiBase : MonoBehaviour
{
    [SerializeField] MissonManager _mM;
    [SerializeField] GpsLocalizador _gps;

    [SerializeField] GameObject _stop;
    [SerializeField] MeshRenderer _render; 
    [SerializeField] CarControler2 _car;

    bool _isInside = false;


    



    // Start is called before the first frame update
    void Start()
    {
        _gps.Target(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        MissonStarts();
    }
    private void OnTriggerEnter(Collider other)
    {
        CarControler2 car = other.gameObject.GetComponent<CarControler2>();
        if (car != null)
        {
            _isInside = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        CarControler2 car = other.gameObject.GetComponent<CarControler2>();
        if (car != null)
        {
            _isInside = false;
        }
    }
    

    void MissonStarts()
    {
        if(_isInside == true)
        {
            _stop.SetActive(true);
        }
        else
        {
            _stop.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isInside == true)
        {
        
            _mM.ImNeedARide();
            _isInside = false;
            _stop.SetActive(false);
            //gameObject.SetActive(false);


        }
    }
    
     
}
