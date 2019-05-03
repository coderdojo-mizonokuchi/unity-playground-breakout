using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private Vector3 startPos = new Vector3(-11f, 6f, 0);
    private Vector2 blockSize = new Vector2(2f, 1f);
    private const int MAX_BLOCK_X = 12;
    public GameObject prefabBlockSquare = null;
    public GameObject prefabBlockHexagon = null;
    public int blockHexagonMax = 5;
    public int blockRowNum = 4;

    // Start is called before the first frame update
    void Start()
    {
        InitBlocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitBlocks()
    {
        SpriteRenderer spriteRenderer = null;
        int blockMax = blockRowNum * MAX_BLOCK_X;
        GameObject[] blocks = new GameObject[blockMax];
        Color[] colors = new Color[] { new Color32(192, 64, 64, 255), new Color32(64, 192, 64, 255), new Color32(192, 64, 192, 255), new Color32(64, 192, 192, 255) };
        // Hexagonブロック作成.
        for (int i=0; i < blockHexagonMax; i++)
        {
            blocks[i] = Instantiate(prefabBlockHexagon);
            blocks[i].transform.SetParent(transform);
        }
        // Squareブロック作成.
        for (int i=blockHexagonMax; i < blockMax; i++)
        {
            blocks[i] = Instantiate(prefabBlockSquare);
            blocks[i].transform.SetParent(transform);
        }
        // シャッフル.
        for (int i=0; i < blocks.Length; i++)
        {
            int randIdx = Random.Range(0, blocks.Length);
            GameObject tmp = blocks[i];
            blocks[i] = blocks[randIdx];
            blocks[randIdx] = tmp;
        }
        // 配置と色決定.
        for (int by=0; by < blockRowNum; by++)
        {
            for (int bx=0; bx < MAX_BLOCK_X; bx++)
            {
                int idx = by * MAX_BLOCK_X + bx;
                spriteRenderer = blocks[idx].GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.color = colors[Random.Range(0, colors.Length)];
                }
                blocks[idx].transform.position = startPos + new Vector3(bx * blockSize.x, -(by * blockSize.y), 0f);
            }
        }
    }
}
