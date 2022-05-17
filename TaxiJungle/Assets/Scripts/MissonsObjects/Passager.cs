using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Passager : MonoBehaviour
{
    [SerializeField] Transform _goalSpot;
    [SerializeField] GameObject _goal;
    [SerializeField] GpsLocalizador _gps;
    [SerializeField] DialogTrigger _Dialogue;
    [SerializeField] PhoneTrigger _phone;
    [SerializeField] PaymentTrigger _Payment;
    

    private void Start()
    {
        _phone.StartPhoneDialogue();
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        CarControler2 car = other.gameObject.GetComponent<CarControler2>();
        if (car != null)
        {
            
            
            _Dialogue.StartDialogue();
            GameObject goal = Instantiate(_goal);
            goal.transform.position = _goalSpot.position;
            car.GetComponentInChildren<GpsLocalizador>().Target(goal);
            Destroy(gameObject);
        }
    }

    public void LastDialogue()
    {
        _Payment.StartPaymentDialogue();
    }

    


}
