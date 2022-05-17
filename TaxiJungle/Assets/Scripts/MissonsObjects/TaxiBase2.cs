using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaxiBase2 : MissonsInteract
{
    [SerializeField] MissonManager _mM;

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
    private void Update()
    {
        SapceSign();
        _gps.Target(this.gameObject);
        StartMisson();
    }

    void StartMisson()
    {
        if(_isReady == true && Input.GetKeyDown(KeyCode.Space))
        {
            _mM.ImNeedARide();
            gameObject.SetActive(false);
            _stop.SetActive(false);
            _space.SetActive(false);

        }
    }


}
