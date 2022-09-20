using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    public Block[] blocks;

    [SerializeField]
    int _blockCount;

    void Start()
    {
        blocks = FindObjectsOfType<Block>();
        _blockCount = blocks.Length;

        // Subscribe to the OnBeingHit event
        foreach (Block block in blocks)
        {
            block.OnBeingHit += HandleBlockBeingHit;
        }

        FindObjectOfType<BallController>().OnMouseClick +=
            HandleBallBeingClicked;
    }

    void Update()
    {
        HandleLevelComplete();
    }

    void HandleBlockBeingHit()
    {
        _blockCount--;
    }

    void HandleBallBeingClicked()
    {
        foreach (Block block in blocks)
        {
            if (!block.gameObject.activeSelf)
            {
                block.gameObject.SetActive(true);
            }
        }

        _blockCount = blocks.Length;
    }

    void HandleLevelComplete()
    {
        if (_blockCount == 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
