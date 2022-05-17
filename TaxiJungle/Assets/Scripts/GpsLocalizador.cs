using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpsLocalizador : MonoBehaviour
{
    [SerializeField] GameObject _theFocus;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    
    void Update()
    {
        // A localizção do ponto de foco do gps e sempre este Trasform;
        transform.LookAt(_theFocus.transform.position);
    }

    //Qual Objecto deve o gps sueguir;
     public void Target(GameObject focos)
    {
        _theFocus = focos;
       
    }
}
