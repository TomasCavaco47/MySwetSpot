using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler2 : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float _maxSpeed, _brakes, _turnSpeed, _realSpeed, _accelarition;
    [SerializeField] GameObject _driftmarc1, _driftmarc2;
    float _currentSpeed = 0;
    float _steerDirection, _outWardsDriftForce = 50000;
    bool _isSliding = false;
    bool _driftRight = false ,_driftLeft = false;
    

    
    public float RealSpeed { get => _realSpeed; set => _realSpeed = value; }



    #region MonoBehaviour
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (DialogueManager.IsActive == true)
            return;

        Move();
        Steer();
    }
    // Update is called once per frame
    void Update()
    {
        Drift();
       
    }
    #endregion

    #region CarControls
    void Move()
    {
        _realSpeed = transform.InverseTransformDirection(_rb.velocity).z;// velocidade real?? , o gajo do tuturial falou sobre o cabelo do personagem "estranho"
       
        if( Input.GetKey(KeyCode.W))
        {
            //acelaração
            _currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed, Time.deltaTime * _accelarition);
        }
        else if(Input.GetKey ( KeyCode.S))
        {
            //Travão   tenta mudar o -_maxSpeed porBrakes
            _currentSpeed = Mathf.Lerp(_currentSpeed, -_maxSpeed / 1.75f, 1f * Time.deltaTime);
        }
        else
        {
            //carro parrado
            _currentSpeed = Mathf.Lerp(_currentSpeed, 0, Time.deltaTime * 1.5f);
        }

        //aplicar a força no carro
        Vector3 vel = transform.forward * _currentSpeed;
        //vel.y = _rb.velocity.y;
        _rb.velocity = vel;

    }
    void Steer()
    {
        
        //_turnInput = Input.GetAxisRaw("Horizontal");
        //float newRotation = _realSpeed > 30 ? _turnSpeed / 1.5f * _turnInput * Time.deltaTime /** Input.GetAxisRaw("Vertical")*/ :  _turnSpeed * _turnInput * Time.deltaTime /** Input.GetAxisRaw("Vertical")*/;  
        //transform.Rotate(0, newRotation, 0, Space.World);

        _steerDirection = Input.GetAxisRaw("Horizontal");
        Vector3 steerDirVect;// e usado para a rotação final do carro para virar

        float _steerAmount = 0;

        //drifts
        if (_driftLeft && !_driftRight)
        {
            _steerDirection = Input.GetAxis("Horizontal") < 0 ? -1.5f : -0.5f;
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(90, -15f, 0), 8f * Time.deltaTime);
            _currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed / 3, Time.deltaTime * 0.5f);

            if (_isSliding)
            {
                _rb.AddForce(transform.right * _outWardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
                //Vector3.Dot(transform.right, _rb.velocity);
            }


        }
        else if (_driftRight && !_driftLeft)
        {
            _steerDirection = Input.GetAxis("Horizontal") > 0 ? 1.5f : 0.5f;
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(90, 15f, 0), 8f * Time.deltaTime);
            _currentSpeed = Mathf.Lerp(_currentSpeed, _maxSpeed / 3, Time.deltaTime * 0.5f);
            if (_isSliding)
            {
                _rb.AddForce(transform.right * -_outWardsDriftForce * Time.deltaTime, ForceMode.Acceleration);
                //Vector3.Dot(transform.right, _rb.velocity);
            }
        }
        else
        {
            transform.GetChild(0).localRotation = Quaternion.Lerp(transform.GetChild(0).localRotation, Quaternion.Euler(90, 0f, 0), 8f * Time.deltaTime);
        }

        //rotação Viragem 
        //parar de rodar quando o carro parra 
        if (_realSpeed > 2 || _realSpeed <-2)
        {
            _steerAmount = _realSpeed > 30 ? _turnSpeed / 1.5f * _steerDirection : _steerAmount = _turnSpeed * _steerDirection;
            
        }
        //rodar menos ao abrandar
        if (_realSpeed <30 )
        {
            _steerAmount = Mathf.Lerp(_steerAmount, 0, Time.deltaTime * 25);
        }
        
        steerDirVect = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + _steerAmount, transform.eulerAngles.z);
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, steerDirVect, 3 * Time.deltaTime);
    }

    //checar se o butão de drift é precionado
    void Drift()
    {
    
            if(Input.GetKeyDown(KeyCode.Space) &&_steerDirection > 0)
            {
               _driftRight = true;
               _driftLeft = false;
            _driftmarc1.SetActive(true);
            _driftmarc2.SetActive(true);

            }
            else if(Input.GetKeyDown(KeyCode.Space) && _steerDirection < 0)
            {
               _driftRight = false;
               _driftLeft = true;
            }
        
    
        if(Input.GetKeyUp(KeyCode.Space) || _realSpeed <50)
        {
            _driftLeft = false;
            _driftRight = false;
            _isSliding = false;
            _driftmarc1.SetActive(false);
            _driftmarc2.SetActive(false);

        }
    }

    #endregion

    
  

}

