using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] Passager _passager;
    [SerializeField] GameObject _base;
    [SerializeField] TaxiBase bas;
    [SerializeField] GpsLocalizador _gps;
    // Start is called before the first frame update
    void Awake()
    {

        _base = GameObject.Find("TaxiBase");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        CarControler2 car = other.gameObject.GetComponent<CarControler2>();
        if (car != null)
        {
            //bas.gameObject.SetActive(false);
            car.GetComponentInChildren<GpsLocalizador>().Target(_base);
            _passager.LastDialogue();
            Destroy(gameObject);
        }
    }
}
