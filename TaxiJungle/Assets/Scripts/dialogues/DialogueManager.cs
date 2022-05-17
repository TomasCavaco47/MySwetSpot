using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Image _actorImage;
    [SerializeField] Text _actorName;
    [SerializeField] Text _messageText;
    [SerializeField] RectTransform _backgroundBox;

    Message[] _currentmessages;
    Actor[] _currentActors;
    int _activeMessage = 0;
    [SerializeField] static bool _isActive = false;

    public static bool IsActive { get => _isActive; set => _isActive = value; }

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        _currentmessages = messages;
        _currentActors = actors;
        _activeMessage = 0;
        _isActive = true;
        Debug.Log("started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
        _backgroundBox.LeanScale(Vector3.one, 0.3f).setEaseInOutExpo();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = _currentmessages[_activeMessage];
        _messageText.text = messageToDisplay._Message;

        Actor actorToDisplay = _currentActors[messageToDisplay._AcotorId];
        _actorName.text = actorToDisplay._Name;
        _actorImage.sprite = actorToDisplay._Sprite;

        AnimateTextColor();
    }

    public void NextMessage()
    {
        _activeMessage++;
        if(_activeMessage < _currentmessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("covesation endende!");
            _isActive = false;
            _backgroundBox.LeanScale(Vector3.zero, 0.3f).setEaseInOutExpo();
        }
    }
    void AnimateTextColor()
    {
        LeanTween.textAlpha(_messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(_messageText.rectTransform, 1f, 0.5f);

    }

    // Start is called before the first frame update
    void Start()
    {
        _backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isActive == true)
        {
            NextMessage();
        }
    }
}
