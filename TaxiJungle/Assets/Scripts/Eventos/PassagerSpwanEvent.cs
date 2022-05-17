using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassagerSpwanEvent : MonoBehaviour
{
    MissonManager _mM;
    [SerializeField] Transform[]  _passagerSpot;
    [SerializeField] GameObject[] _passagers;
    [SerializeField] GpsLocalizador _gps;
    
    // Start is called before the first frame update
    void Awake()
    {
        _mM = GetComponent<MissonManager>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        _mM.PassagerSpwanEvent1 += SpawnPasseger;
    }
    void OnDisable()
    {
        _mM.PassagerSpwanEvent1 -= SpawnPasseger;
    }

    void SpawnPasseger()
    {
        int _wathClient;
        int _wereTheClientIs;
        _wereTheClientIs = Random.Range(0, 2);
        _wathClient = Random.Range(0, 2);
        GameObject client = Instantiate(_passagers[_wathClient]);
        client.transform.position = _passagerSpot[_wereTheClientIs].position;
        Debug.Log(client);
        _gps.Target(client);
    }
}
