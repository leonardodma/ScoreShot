using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEffects : MonoBehaviour
{
    // Variables to create the trails
    public int trailAmount = 10;

    float _trailGap;

    // GameObjects to create the trails
    public GameObject trailPrefab;

    GameObject[] _trails;

    // Start is called before the first frame update
    void Start()
    {
        _trailGap = 1f / trailAmount;
        SpawnTrail();
    }

    void SpawnTrail()
    {
        _trails = new GameObject[trailAmount];
        for (int i = 0; i < trailAmount; i++)
        {
            GameObject _dot = Instantiate(trailPrefab);
            _dot.SetActive(false);
            _trails[i] = _dot;
        }
    }

    public void SetTrailPosition(Vector3 startPosition, Vector3 endPosition)
    {
        for (int i = 0; i < trailAmount; i++)
        {
            _trails[i].transform.position =
                Vector2.Lerp(startPosition, endPosition, _trailGap * i);
        }
    }

    public void SetTrailActive(bool isActive)
    {
        for (int i = 0; i < trailAmount; i++)
        {
            _trails[i].SetActive(isActive);
        }
    }
}
