using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{


    [SerializeField]
    private int percentChanceForBlock = 30;

    [SerializeField]
    private int percentChanceForBonusBall = 8;

    [SerializeField]
    private Block blockPrefab = null;

    [SerializeField]
    private BonusBall bonusBall;

    private float offset = 0.9f;

    private List<Block> blocks;

    private List<BonusBall> bonusBalls;

    private int maxBlocksInRow = 6;

    private UnityEngine.Random random;

    public int rowsSpawned;

    private void Awake()
    {
        blocks = new List<Block>();
        bonusBalls = new List<BonusBall>();
        rowsSpawned = 0;
        SpawnRowOfBlocks();

    }

    private void SpawnRowOfBlocks()
    {
        foreach (var item in blocks)
        {
            if (item != null)
                item.transform.position += Vector3.down * offset;
        }

        foreach (var item in bonusBalls)
        {
            if (item != null)
                item.transform.position += Vector3.down * offset;
        }


        int respawnedBlocks = 0;

        while (respawnedBlocks == 0)
        {

            for (int i = 0; i < maxBlocksInRow; i++)
            {
                if (UnityEngine.Random.Range(0, 100) > percentChanceForBlock)
                {
                    var block = Instantiate(blockPrefab, SetPosition(i), Quaternion.identity, transform);
                    int blockHp = UnityEngine.Random.Range(1, 3) + rowsSpawned;
                    block.SetHp(blockHp);
                    blocks.Add(block);
                    respawnedBlocks++;
                }
                else
                {
                    if (UnityEngine.Random.Range(0, 100) < percentChanceForBonusBall)
                    {
                        var tmp = Instantiate(bonusBall, SetPosition(i), Quaternion.identity);
                        bonusBalls.Add(tmp);
                    }
                }
            }
        }

        rowsSpawned++;
        STF.uimanager.SetLevelText(rowsSpawned);
    }

    private Vector3 SetPosition(int i)
    {
        Vector3 position = transform.position;

        position += Vector3.right * offset * i;

        return position;
    }

    public void CreateRowOfBlocks()
    {
        SpawnRowOfBlocks();
    }

    public void SetAlphaChanelToBlocks(float value)
    {
        foreach (Block item in blocks)
        {
            if (item != null)
            {
                var color = item.GetComponentInParent<Renderer>().material.color;

                color.a = value;
            }
        }
    }

}
