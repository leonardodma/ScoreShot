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
        HandleLevelBeingCompleted();
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

    void HandleLevelBeingCompleted()
    {
        if (_blockCount == 0)
        {
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

        }
    }
}
