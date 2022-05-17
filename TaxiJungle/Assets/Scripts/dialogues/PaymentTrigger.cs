using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaymentTrigger : MonoBehaviour
{
    [SerializeField] Message[] _messages;
    [SerializeField] Actor[] _actors;



    public void StartPaymentDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(_messages, _actors);
    }
}

[System.Serializable]
public class MessagePayment
{
    [SerializeField] int _acotorId;
    [SerializeField] string _message;

    public string _Message { get => _message; set => _message = value; }
    public int _AcotorId { get => _acotorId; set => _acotorId = value; }
}

[System.Serializable]
public class ActorPayment
{
    [SerializeField] string _name;
    [SerializeField] Sprite _sprite;

    public string _Name { get => _name; set => _name = value; }
    public Sprite _Sprite { get => _sprite; set => _sprite = value; }
}