using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    private const float SIZE_PER_LINE = 40;

    [SerializeField] private RectTransform frame;
    [SerializeField] private TMP_Text content;

    public void SetContent(Message message)
    {
        content.text = message.content;
    }
    public void StartAnimation()
    {
        StartCoroutine(ReceiveMessageAnimation());
    }
    private float CalculateHeight()
    {
        content.ForceMeshUpdate();
        return Mathf.Clamp(content.textInfo.lineCount * SIZE_PER_LINE, 70, 600);
    }
    private IEnumerator ReceiveMessageAnimation()
    {
        var messageSpace = FindObjectOfType<MessageSpace>().gameObject.GetComponent<RectTransform>();
        float target = CalculateHeight();
        float speed = target / 0.25f;
        frame.sizeDelta = new Vector2(frame.sizeDelta.x, 0);
        while (frame.sizeDelta.y < target)
        {
            frame.sizeDelta += Vector2.up * Time.deltaTime * speed;
            LayoutRebuilder.ForceRebuildLayoutImmediate(messageSpace);
            yield return null;
        }
        yield return null;
    }
}
public struct Message
{
    public string content;
    public Message(string content)
    {
        this.content = content;
    }
}