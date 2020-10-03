using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

public class DecisionBox : MonoBehaviour
{
    private const float SIZE_PER_LINE = 40;

    [SerializeField] private RectTransform frame;
    [SerializeField] private TMP_Text content;
    [SerializeField] private Image icon;

    public int index;
    public void Start()
    {
        FindObjectOfType<MessageSpace>().ReceiveAnswer += PlayerAnswered;
    }
    public void PlayerAnswered(int index)
    {
        GetComponent<Button>().interactable = false;
        if(index != this.index)
            NotDecidedAnimation();
        FindObjectOfType<MessageSpace>().ReceiveAnswer -= PlayerAnswered;
    }
    public void Decide()
    {
        FindObjectOfType<MessageSpace>().Answer(index);
    }
    public void SetContent(Decision decision, int index)
    {
        content.text = decision.content;
        this.index = index;
    }
    public void StartAnimation()
    {
        StartCoroutine(ReceiveDecisionAnimation());
    }
    private float CalculateHeight()
    {
        content.ForceMeshUpdate();
        return Mathf.Clamp(content.textInfo.lineCount * SIZE_PER_LINE, 120, 600);
    }
    private IEnumerator ReceiveDecisionAnimation()
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
    public void NotDecidedAnimation()
    {
        Color c = frame.GetChild(0).GetComponent<Image>().color;
        c /= 2f;
        c.a = 1;
        frame.GetChild(0).GetComponent<Image>().DOColor(c, 0.5f);
        //gameObject.GetComponent<CanvasGroup>().DOFade(0.5f, 0.5f);
        GetComponent<Button>().interactable = false;
    }
}
public class Decision
{
    public string content;
    public int type;
    public Decision(int type, string content)
    {
        this.content = content;
        this.type = type;
    }
}