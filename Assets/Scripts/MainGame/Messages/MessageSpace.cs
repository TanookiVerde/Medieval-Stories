using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MessageSpace : MonoBehaviour
{
    public Transform messageRoot;

    public List<Message> messageList = new List<Message>();
    public List<Decision> currentChoices = new List<Decision>();

    public GameObject messagePrefab;
    public GameObject decisionPrefab;
    public Transform emptyContent;

    public delegate void PlayerAnswer(int index);
    public event PlayerAnswer ReceiveAnswer;

    public void NewMessage(Message message)
    {
        currentChoices = new List<Decision>();
        var go = Instantiate(messagePrefab, messageRoot);
        emptyContent.SetAsLastSibling();
        go.GetComponent<MessageBox>().SetContent(message);
        go.GetComponent<MessageBox>().StartAnimation();
        messageList.Add(message);
        messageRoot.parent.parent.GetComponent<ScrollRect>().DONormalizedPos(Vector2.zero, 0.5f);
    }
    public int NewDecision(Decision decision)
    {
        currentChoices.Add(decision);
        int index = currentChoices.Count - 1;
        var go = Instantiate(decisionPrefab, messageRoot);
        emptyContent.SetAsLastSibling();
        go.GetComponent<DecisionBox>().SetContent(decision, index);
        go.GetComponent<DecisionBox>().StartAnimation();
        messageRoot.parent.parent.GetComponent<ScrollRect>().DONormalizedPos(Vector2.zero, 0.5f);
        return index;
    }
    public void Answer(int index)
    {
        ReceiveAnswer(index);
    }
    public void Reset()
    {
        currentChoices = new List<Decision>();
        messageList = new List<Message>();
        
    }
}
