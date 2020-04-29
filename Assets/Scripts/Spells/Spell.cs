using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spell : MonoBehaviour
{
    [Header("Settings")]
    public string name;
    public bool isSingular;
    public float duration;
    public float cooldownLength;
    public KeyCode key;

    [Header("References")]
    public Sprite icon;
    public Image img_Cooldown;
    public TMPro.TextMeshProUGUI txt_description;

    [Header("Properties")]
    public bool isExecuting;
    public bool onCooldown;

    private void Start()
    {
        txt_description.text = name;
    }

    private void Update()
    {
        if(isExecuting)
        {
            Effect();
        }
    }

    public virtual void Effect()
    {
        print(name + " is doing something.");

        if(isSingular)
        {
            EndSpell();
        }
    }

    public virtual void StartSpell()
    {
        isExecuting = true;

        if (!isSingular)
        {
            //Start End coroutine
            StartCoroutine(EndTimer());
        }
    }

    public virtual IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(duration);

        //End
        if(isExecuting)
            EndSpell();
    }

    public virtual void EndSpell()
    {
        isExecuting = false;

        //Start cooldown
        StartCoroutine(Cooldown());
    }

    public IEnumerator Cooldown()
    {
        img_Cooldown.gameObject.SetActive(true);

        float progress = 0f;

        while(progress < cooldownLength)
        {
            img_Cooldown.fillAmount = progress / cooldownLength;
            progress += Time.deltaTime;

            yield return null;
        }
        
        if(progress >= cooldownLength)
        {
            img_Cooldown.gameObject.SetActive(false);
        }
    }
}
