using DG.Tweening;
using UnityEngine;
using Zenject;
public class BonusesController : MonoBehaviour
{
    private int randomBonus;
    private InvulnerabilityBonus invulnerabilityBonus;
    private LittleSizeBonus littleSizeBonus;
    [Inject] private BarrierController barrierController;
    private void Awake()
    {
        invulnerabilityBonus = GetComponent<InvulnerabilityBonus>();
        littleSizeBonus = GetComponent<LittleSizeBonus>();
        SelectBonus();
        
    }
    private void OnEnable()
    {
        SelectBonus();
        this.transform.DOLocalMoveY((transform.localPosition.y - barrierController.distanceMoving), barrierController.speed).SetEase(Ease.Linear).OnComplete(Deactivation);
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
                invulnerabilityBonus.enabled = true;
                littleSizeBonus.enabled = false;
                break;
            case 2:
                invulnerabilityBonus.enabled = false;
                littleSizeBonus.enabled = true;
                break;
            default:
                break;
        }
    }
}
