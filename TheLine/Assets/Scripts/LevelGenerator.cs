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
    private int entryPointIndex = 3;
    private Direction direction;
    private Direction prohibitedDirection;
    private int countOfForwardMove = 0;
    private List<int> freeCellPositionIndices = new List<int>();
    private void Awake()
    {
        cam = Camera.main;
    }



    enum Direction
    {
         Forward,
         Left,
         Right
    }





    void Start()
    {
        DisplacementGridGeneration();
        StartingLocationGeneration();
        prohibitedDirection = Direction.Forward;
        InvokeRepeating("randomDirectionGenerator", 0, 1);
    }


    private void randomDirectionGenerator()
    {
        freeCellPositionIndices.Clear();
        freeCellPositionIndices.Add(entryPointIndex);

        if (countOfForwardMove <=5)
        {
            if (entryPointIndex == 1 && prohibitedDirection == Direction.Right)
            {
                direction = Direction.Forward;
                countOfForwardMove++;
                AddNewRowOnMap();
                return;
            }

            if (entryPointIndex == numberOfBlocksHorizontally - 1 && prohibitedDirection == Direction.Left)
            {
                direction = Direction.Forward;
                AddNewRowOnMap();
                countOfForwardMove++;
                return;
            }
        }
        else
        {

        }

        int randEnamDir = Random.Range(0, 3);
        direction = (Direction)randEnamDir;
        while (prohibitedDirection == direction)
        {
            randEnamDir = Random.Range(0, 3);
            direction = (Direction)randEnamDir;
        }

        if (direction == Direction.Forward)
        {
            AddNewRowOnMap();
            return;
        }

        if (direction == Direction.Left)
        {
            prohibitedDirection = Direction.Right;
            int newEntryPointIndex = Random.Range(1, entryPointIndex);
            for (int i = newEntryPointIndex; i < entryPointIndex; i++)
            {
                freeCellPositionIndices.Add(i);
            }
            entryPointIndex = newEntryPointIndex;
            AddNewRowOnMap();
        }

        if (direction == Direction.Right)
        {
            prohibitedDirection = Direction.Left;
            int newEntryPointIndex = Random.Range(entryPointIndex, numberOfBlocksHorizontally);
            for (int i = entryPointIndex; i < newEntryPointIndex; i++)
            {
                freeCellPositionIndices.Add(i);
            }
            entryPointIndex = newEntryPointIndex;
            AddNewRowOnMap();
        }
    }

    public void AddNewRowOnMap()
    {

        string tnp = "entryPointIndex: " + entryPointIndex + " | ";
        foreach (var item in freeCellPositionIndices)
        {
            tnp += item + ",";
        }
       // Debug.Log(tnp);


        Debug.Log("-------------");
        for (int i = 0; i < numberOfBlocksHorizontally; i++)
        {
            if (!freeCellPositionIndices.Contains(i))
            {
                _pool.GetFreeElement(displacementGridVectors[i]);
                Debug.Log(i);
            }


        }
        Debug.Log("-------------");
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
                if (i <= 2 && (j <= 2 || j>=4))
                {
                    _pool.GetFreeElement(new Vector2(displacementGridVectors[j].x, posY));
                }

                if (i > 2 && (j <= 1 || j >= 5))
                {
                    if (i<=4)_pool.GetFreeElement(new Vector2(displacementGridVectors[j].x, posY));
                }

                if (i > 4 && (j <= 0 || j >= 6))
                {
                    _pool.GetFreeElement(new Vector2(displacementGridVectors[j].x, posY));
                }

            }
            posY -= y_axisDisplacementOfBarriers;
        }

    }
}
