using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]private int _score=0;
    // Update is called once per frame
    void Update()
    {
        Coin._onTake.AddListener(AddPoint);
    }

    private void AddPoint()
    {
        _score++;
    }
}
