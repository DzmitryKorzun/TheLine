using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class LevelGenerator : MonoBehaviour
{
    [Inject] private Pool _pool;
    [Inject] private PoolObject barrier;
    private List<Vector2> displacementGridVectors = new List<Vector2>();
    private Camera cam;
    const int numberOfBlocksHorizontally = 7;
    const int numberOfBlocksVertical = 10;
    const float verticalStartPosition = 0.689f;
    private float x_axisDisplacementOfBarriers;
    private float y_axisDisplacementOfBarriers;

    private void Awake()
    {
        cam = Camera.main;

    }


    void Start()
    {
        DisplacementGridGeneration();
        StartingLocationGeneration();
    }




    private void AddNewRowOfMap()
    {

    }

    private void DisplacementGridGeneration()
    {
        x_axisDisplacementOfBarriers = barrier.gameObject.GetComponent<SpriteRenderer>().sprite.rect.width/ barrier.gameObject.transform.localScale.x / 100 / 2 - 0.025f; // 0.025f - Floating point error correction
        float posX = 0;
        for (int i = 0; i < numberOfBlocksHorizontally; i++)
        {
            displacementGridVectors.Add(new Vector2(posX, verticalStartPosition));
            posX += x_axisDisplacementOfBarriers;
        }
    }

    private void StartingLocationGeneration()
    {

        y_axisDisplacementOfBarriers = barrier.gameObject.GetComponent<SpriteRenderer>().sprite.rect.height / barrier.gameObject.transform.localScale.x / 100 / 2 - 0.025f; // 0.025f - Floating point error correction
        float posY = verticalStartPosition;
        for (int i = 0; i < numberOfBlocksVertical; i++)
        {
            for (int j = 0; j < numberOfBlocksHorizontally; j++)
            {
                if (j != 3)
                {
                    var block = _pool.GetFreeElement(new Vector2(displacementGridVectors[j].x, posY));
                }
            }
            posY -= y_axisDisplacementOfBarriers;
        }

    }
}
