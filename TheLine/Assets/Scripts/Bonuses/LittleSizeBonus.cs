using UnityEngine;
using Zenject;
using DG.Tweening;
public class LittleSizeBonus : MonoBehaviour, IBonus
{
    [SerializeField] private float durection = 5f;
    [SerializeField] private float reductionRatio = 0.5f;
    [Inject] PersonController personController;
    private float originalScale;
    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().DOColor(Color.yellow, 0.2f).SetLoops(100, LoopType.Yoyo);
        originalScale = personController.transform.localScale.x;
    }

    public void EffectOff()
    {
        personController.isVulnerable = false;
        personController.transform.DOScale(originalScale, 0.25f);
    }

    public void EffectOn()
    {
        personController.isVulnerable = true;
        personController.transform.DOScale(originalScale* reductionRatio, 0.25f).SetLoops(100, LoopType.Yoyo);
        Invoke("EffectOff", durection);
    }
}
