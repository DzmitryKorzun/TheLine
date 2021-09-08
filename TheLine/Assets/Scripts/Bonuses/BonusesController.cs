using DG.Tweening;
using UnityEngine;
using Zenject;
public class BonusesController : MonoBehaviour
{
    private int randomBonus;
    [Inject] private BarrierController barrierController;
    private void Awake()
    {
        this.GetComponent<SpriteRenderer>().DOColor(Color.yellow, 0.2f).SetLoops(100, LoopType.Yoyo);
        SelectBonus();
        
    }
    private void OnEnable()
    {
        SelectBonus();
        Debug.Log(this.transform.position.y);
        this.transform.DOLocalMoveY(0.6f-barrierController.distanceMoving, barrierController.speed).SetEase(Ease.Linear).OnComplete(Deactivation);
    }

    private void Deactivation()
    {
        this.gameObject.SetActive(false);
        this.transform.DOKill();
    }
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    private void SelectBonus()
    {
        randomBonus = Random.Range(1, 3);

        switch (randomBonus)
        {
            case 1:
                this.gameObject.AddComponent<InvulnerabilityBonus>();
                Destroy(this.gameObject.GetComponent<LittleSizeBonus>());
                break;
            case 2:
                this.gameObject.AddComponent<LittleSizeBonus>();
                Destroy(this.gameObject.GetComponent<InvulnerabilityBonus>());
                break;
            default:
                break;
        }
    }
}
