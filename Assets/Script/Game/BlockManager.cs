using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{


    [SerializeField]
    private int percentChanceForBlock = 30;

    [SerializeField]
    private Block blockPrefab = null;

    private float offset = 0.9f;

    private List<Block> blocks;

    private int maxBlocksInRow = 6;

    private UnityEngine.Random random;

    public int rowsSpawned;

    //private void Awake()
    //{
    //    blocks = new List<Block>();
    //    rowsSpawned = 0;
    //    SpawnRowOfBlocks();
        
    //}

    private void Start()
    {

        blocks = new List<Block>();
        rowsSpawned = 0;
        SpawnRowOfBlocks();
    }

    private void SpawnRowOfBlocks()
    {

        foreach (Block item in blocks)
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
                    int blockHp = UnityEngine.Random.Range(1,3) + rowsSpawned;
                    block.SetHp(blockHp);
                    blocks.Add(block);
                    respawnedBlocks++;
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

}
