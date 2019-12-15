using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class Test : MonoBehaviour
{
    [SerializeField]
    private string saveFileName;
    [SerializeField]
    private string saveStateName;
    private string currentMessages;
    private int parseCounter = 0;
    private Story story;
    private bool choosing = false;
    [SerializeField]
    TextAsset inkText;

    private void Start()
    {
        StartCoroutine(Animation());
        currentMessages = "";
        FindObjectOfType<MessageSpace>().ReceiveAnswer += ReceiveTest;
    }
    private IEnumerator Animation()
    {
        story = new Story(inkText.text);
        //while (Next())
        //{
          yield return null;
        //}
    }
    public void ReceiveTest(int index)
    {
        print("RECEBI A RESPOSTA::" + index);
        story.ChooseChoiceIndex(index);
        choosing = false;
        Line();
    }
    public void Next()
    {
        if (story.canContinue)
        {
            //if (Input.GetButtonDown("Fire1"))
            //{
                Line();
            //}
        }
        else if (story.currentChoices.Count > 0 && !choosing)
        {
            Choice();
        }
        //else if (!choosing)
            //return false;

        //return true;
    }
    private void Line()
    {
        string text = story.Continue().Trim();
        foreach (object o in story.currentTags)
        {
            if(o.ToString()[0] == '&')
            {
                FindObjectOfType<ItemManager>().AddItem(o.ToString().Substring(1));
            }
        }
        FindObjectOfType<MessageSpace>().NewMessage(new Message(text));
        AddMessage(text);
    }
    private void Line(string line)
    {
        FindObjectOfType<MessageSpace>().NewMessage(new Message(line));
        foreach(DecisionBox d in GameObject.FindObjectsOfType<DecisionBox>())
        {
            d.NotDecidedAnimation(); //to do:otimizar
        }
    }
    private void Choice()
    {
        for (int i = 0; i < story.currentChoices.Count; i++)
        {
            Choice choice = story.currentChoices[i];
            FindObjectOfType<MessageSpace>().NewDecision(new Decision(0, choice.text));
            AddMessage(choice.text, false);
            choosing = true;
        }
    }
    private void Choice(string choice)
    {
        FindObjectOfType<MessageSpace>().NewDecision(new Decision(0, choice));
    }
    public void SaveStory()
    {
        PlayerPrefs.SetString(saveFileName, currentMessages);
        PlayerPrefs.SetString(saveStateName, story.state.ToJson());
        FindObjectOfType<ItemManager>().SavePlayerItems();
    }
    public void LoadStory()
    {
        FindObjectOfType<MessageSpace>().Reset();
        FindObjectOfType<ItemManager>().LoadPlayerItems();
        StartCoroutine(_LoadStory());
    }
    private IEnumerator _LoadStory()
    {
        story.state.LoadJson(PlayerPrefs.GetString(saveStateName));
        currentMessages = PlayerPrefs.GetString(saveFileName);
        GameObject messageParent = GameObject.Find("Content");
        foreach(Transform t in messageParent.transform.GetComponentInChildren<Transform>())
        {
            if (t != messageParent.transform)
                Destroy(t.gameObject);
        }
        for(parseCounter = 0; parseCounter < currentMessages.Length; parseCounter++)
        {
            if (currentMessages[parseCounter] == '*')
                yield return ParseLine();
            else if (currentMessages[parseCounter] == '$')
                yield return ParseChoice();
        }
        choosing = false;
    }
    private IEnumerator ParseLine()
    {
        parseCounter++;
        string message = "";
        for(; parseCounter < currentMessages.Length; parseCounter++)
        {
            if (currentMessages[parseCounter] == '*' || currentMessages[parseCounter] == '$')
            {
                Line(message);
                parseCounter--;
                FindObjectOfType<MessageSpace>().Reset();
                yield break;
            }
            else
            {
                message += currentMessages[parseCounter];
            }
        }
        Line(message);
        yield return null;
    }
    private IEnumerator ParseChoice()
    {
        parseCounter++;
        string message = "";
        for (; parseCounter < currentMessages.Length; parseCounter++)
        {
            if (currentMessages[parseCounter] == '*' || currentMessages[parseCounter] == '$')
            {
                Choice(message);
                parseCounter--; 
                yield break;
            }
            else
            {
                message += currentMessages[parseCounter];
            }
        }
        Choice(message);
        yield return null;
    }
    private void AddMessage(string message, bool type = true) //true = line, false = decision. * special character from line, $ special character for decision
    {
        print("Added: " + message);
        if(type)
        {
            currentMessages += "*" + message;
        }
        else
        {
            currentMessages += "$" + message;
        }
        print("Total: " + currentMessages);
    }
    public void DeleteSave()
    {
        PlayerPrefs.SetString(saveStateName, "");
        PlayerPrefs.SetString(saveFileName, "");
        FindObjectOfType<MessageSpace>().Reset();
        FindObjectOfType<ItemManager>().DeleteAllItems();
        currentMessages = "";
        parseCounter = 0;
    }
}
