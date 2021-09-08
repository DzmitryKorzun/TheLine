using UnityEngine;
using Zenject;
using DG.Tweening;
public class LittleSizeBonus : MonoBehaviour, IBonus
{
    [SerializeField] private float durection = 5f;
    [SerializeField] private float reductionRatio = 0.5f;
    [Inject] PersonController personController;
    [Inject] BonusPanelController bonusPanel;
    private int time;
    private float originalScale;
    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().DOColor(Color.yellow, 0.2f).SetLoops(100, LoopType.Yoyo);
        originalScale = personController.transform.localScale.x;
        time = Mathf.RoundToInt(durection);
    }

    public void EffectOff()
    {
        bonusPanel.gameObject.SetActive(false);
        personController.isVulnerable = false;
        personController.transform.DOScale(originalScale, 0.25f);
        CancelInvoke();
    }

    public void EffectOn()
    {
        time = Mathf.RoundToInt(durection);
        bonusPanel.gameObject.SetActive(true);
        InvokeRepeating("timer", 0, 1);
        personController.isVulnerable = true;
        personController.transform.DOScale(originalScale* reductionRatio, 0.25f).SetLoops(100, LoopType.Yoyo);
        Invoke("EffectOff", durection);
    }
    private void timer()
    {
        bonusPanel.timeOutput(time.ToString());
        time--;
    }
}
