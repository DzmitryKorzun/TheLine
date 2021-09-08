using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class PersonController : MonoBehaviour
{
    public event Action OnPauseGame;
    public event Action OnStartGame;
    public event Action GameOver;
    public bool isVulnerable = true;
    private Transform personTransform;
    [SerializeField] private float bottomMargin = -2.5f;
    void Start()
    {
        personTransform = this.transform;
    }

    public void СhangeOfLocation(float locX_coordintate)
    {
        personTransform.DOMoveX(locX_coordintate, 0.101f);
    }


    public void Death()
    {
        GameOver?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
     //   OnPauseGame?.Invoke();
        if (collision.gameObject.tag == "Block")
        {
            if (isVulnerable)
            {
                DOTween.KillAll();
                collision.GetComponent<SpriteRenderer>().DOColor(Color.yellow, 0.2f).SetLoops(4, LoopType.Yoyo);
                Death();
            }
            else
            {
                collision.gameObject.SetActive(false);
                collision.transform.DOKill();
            }
        }
        if (collision.gameObject.tag == "Bonus")
        {
            collision.GetComponent<IBonus>().EffectOn();
        }
    }

}
