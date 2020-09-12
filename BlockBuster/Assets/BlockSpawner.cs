using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    public GameObject blockPrefab;
    public int cols;
    public int rows;

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 startPosition = new Vector3(-11.5f, -1, 0);
        Vector2 spacing = new Vector2(2.5f, 1.5f);

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                Vector3 position = startPosition + new Vector3(spacing.x * c, spacing.y * r, 0);
                GameObject block = GameObject.Instantiate(blockPrefab, new Vector3(position.x, 20, 0), Quaternion.identity);
                block.transform.parent = this.transform;
                LeanTween.move(block, position, Random.Range(0.1f, 0.8f)).setEaseOutBounce();
            }
        }
    }
}
