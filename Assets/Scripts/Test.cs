using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Animation());
        FindObjectOfType<MessageSpace>().ReceiveAnswer += ReceiveTest;
    }
    private IEnumerator Animation()
    {
        for (int i = 0; i < 10; i++)
        {
            FindObjectOfType<MessageSpace>().NewMessage(new Message("Hello, World!\nHohohoho\nheheheh\ncatchau"));
            
            yield return new WaitForSeconds(2f);
        }
    }
    public void ReceiveTest(int index)
    {
        print("RECEBI A RESPOSTA::" + index);
    }
}
