using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawnEvent : MonoBehaviour
{
    MissonManager _mM;
    [SerializeField] Transform _GoalSpot;
    [SerializeField] GameObject _goal;
    // Start is called before the first frame update
    void Awake()
    {
        _mM = GetComponent<MissonManager>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        _mM.GoalSpawnEvent1 += SpawnPasseger;
    }
    void OnDisable()
    {
        _mM.GoalSpawnEvent1 -= SpawnPasseger;
    }

    void SpawnPasseger()
    {
        //int _wathClient;
        //int _wereTheClientIs;
        //_wereTheClientIs = Random.Range(0, 10);
        //_wathClient = Random.Range(0, 10);
        GameObject client = Instantiate(_goal);
        client.transform.position = _GoalSpot.position;
    }
}

