using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passager2 : MissonsInteract
{
    [SerializeField] Transform _goalSpot;
    [SerializeField] GameObject _goal;

    [SerializeField] DialogTrigger _Dialogue;
    [SerializeField] PhoneTrigger _phone;
    [SerializeField] PaymentTrigger _Payment;
    #region override
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
    }

    protected override void SapceSign()
    {
        base.SapceSign();
    }
    #endregion
    void Start()
    {
        _phone.StartPhoneDialogue();
    }

    private void Update()
    {
        StartGoal();
    }

    void StartGoal()
    {
        if(_isReady == true && Input.GetKeyDown(KeyCode.Space))
        {
            _Dialogue.StartDialogue();
            GameObject goal = Instantiate(_goal);
            goal.transform.position = _goalSpot.position;
            _gps.Target(goal);
            Destroy(gameObject);
        }
    }
    public void LastDialogue()
    {
        _Payment.StartPaymentDialogue();
    }



}
