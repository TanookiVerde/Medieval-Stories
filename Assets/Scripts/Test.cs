using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Test : MonoBehaviour
{
    private Story story;
    private bool choosing = false;
    [SerializeField]
    TextAsset inkText;

    private void Start()
    {
        StartCoroutine(Animation());
        FindObjectOfType<MessageSpace>().ReceiveAnswer += ReceiveTest;
    }
    private IEnumerator Animation()
    {
        story = new Story(inkText.text);
        while (Next())
        {
          yield return null;
        }
    }
    public void ReceiveTest(int index)
    {
        print("RECEBI A RESPOSTA::" + index);
        story.ChooseChoiceIndex(index);
        choosing = false;
        Line();
    }
    private bool Next()
    {
        if (story.canContinue)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Line();
            }
        }
        else if (story.currentChoices.Count > 0 && !choosing)
        {
            Choice();
        }
        else if (!choosing)
            return false;

        return true;
    }
    private void Line()
    {
        string text = story.Continue().Trim();
        foreach (object o in story.currentTags)
            print(o.ToString());
        FindObjectOfType<MessageSpace>().NewMessage(new Message(text));
    }
    private void Choice()
    {
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];
            FindObjectOfType<MessageSpace>().NewDecision(new Decision(0, choice.text));
            choosing = true;
        }
    }    
}
