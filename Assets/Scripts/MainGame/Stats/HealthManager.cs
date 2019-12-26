using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class HealthManager : MonoBehaviour
{
    private const float EFFECT_DURATION = 0.5f;

    [SerializeField] private TMP_Text healthTxt;

    public Effect damageEffect;
    public Effect recoveryEffect;

    [SerializeField] private int health;

    public void LoadHealth()
    {
        //Load Health Value from loadFile;
        InitHUD();
    }
    public static void TakeDamage(int value)
    {
        var obj = FindObjectOfType<HealthManager>();
        obj.health -= value;
        obj.damageEffect.BeginEffect();
        obj.StartCoroutine(obj.UpdateHUD());
    }
    public static void RecoverHealth(int value)
    {
        var obj = FindObjectOfType<HealthManager>();
        obj.health += value;
        obj.recoveryEffect.BeginEffect();
        obj.StartCoroutine(obj.UpdateHUD());
    }
    public static void InitHUD()
    {
        var obj = FindObjectOfType<HealthManager>();
        obj.healthTxt.text = obj.health.ToString();
    }
    private IEnumerator UpdateHUD()
    {
        int init = int.Parse(healthTxt.text);
        int final = health;
        int delta = Mathf.Abs(final - init);
        int bias = (final - init) / (delta);
        for(int i = 0; i <= delta; i++)
        {
            healthTxt.text = (init + i*bias).ToString();
            yield return new WaitForSeconds(EFFECT_DURATION / delta);
        }
        yield return null;
    }
}
