using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockManager : MonoBehaviour
{
    public Block[] blocks;

    public BallController ball;
    [SerializeField] private AudioSource finishedSoundEffect;
    // [SerializeField] private AudioSource startSoundEffect;

    [SerializeField]
    int _blockCount;

    void Start()
    {
        // startSoundEffect.Play();
        ball = FindObjectOfType<BallController>();
        blocks = FindObjectsOfType<Block>();
        _blockCount = blocks.Length;

        // Subscribe to the OnBeingHit event
        foreach (Block block in blocks)
        {
            block.OnBeingHit += HandleBlockBeingHit;
        }

        ball.OnMouseClick += HandleResetBlocks;
    }

    void Update()
    {
        HandleLevelComplete();
        ball.OnScreenOff += HandleResetBlocks;
    }

    void HandleBlockBeingHit()
    {
        _blockCount--;
    }

    void HandleResetBlocks()
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
            SceneManager.LoadScene("Gol");
        }
        
     }



    }

