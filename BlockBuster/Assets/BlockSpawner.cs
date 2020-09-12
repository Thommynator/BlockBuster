using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject blockPrefab;
    public int cols;
    public int rows;

    void Awake()
    {
        LeanTween.init(800);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)
        {
            SpawnNewBlocks();
        }
    }

    private void SpawnNewBlocks()
    {
        Vector3 startPosition = new Vector3(-11.25f, -1, 0);
        Vector2 spacing = new Vector2(1.6f, 0.7f);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Vector3 position = startPosition + new Vector3(spacing.x * c, spacing.y * r, 0);
                GameObject block = GameObject.Instantiate(blockPrefab, new Vector3(position.x, 20, 0), Quaternion.identity);
                block.transform.parent = this.transform;
                float randomTime = Random.Range(0.1f, 0.5f);
                LeanTween.move(block, position, randomTime).setEaseOutBack();
                LeanTween.scale(block, block.transform.localScale * 0.6f, randomTime / 2).setLoopPingPong(1);
            }
        }
    }
}
