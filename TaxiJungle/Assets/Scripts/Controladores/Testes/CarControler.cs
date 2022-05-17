using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarControler : MonoBehaviour
{
    [SerializeField] Rigidbody _sphereRB;
    [SerializeField] float fwdSpeed, revSpeed, turnSpeed , Acceleration; 
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float airDrag,groundDrag;
   

    float moveInput;
    float turnInput;
    bool isGrouded;

    public float MoveInput { get => moveInput; set => moveInput = value; }

    void Start()
    {
        _sphereRB.transform.parent = null;
        
    }

    void Update()
    {
        //quando os controls verticais são aplicados, vamos dar um valor a variavel de velocidade. 
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        // velocidade do carro
        moveInput *= fwdSpeed > 0 ? fwdSpeed : revSpeed;

        // a posição do carro é a mesma que a esfera
        transform.position = _sphereRB.transform.position;

        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnSpeed * Time.deltaTime,0f));
        float newRotation = turnInput * turnSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newRotation, 0, Space.World);

        //ray cast para checar se o carro esta no chao
        RaycastHit hit;
        isGrouded = Physics.Raycast(transform.position, -transform.up, out hit,1f, groundLayer);

        //rotação do carro no ar
        transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation; 

        if(isGrouded)
        {
            _sphereRB.drag = airDrag;
        }

    }

    private void FixedUpdate()
    {
        if( isGrouded)
        {
            //mexe o carro
            _sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            //mais gravidade
            _sphereRB.AddForce(transform.up * -30f);
        } 
        
        //o movimento da esfera e aplicado quado os valor da velocidade são aplicados
        _sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
    }
}
