using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin coin;
    [SerializeField] private CoinDot[] _coinSpawnDots;
    [SerializeField] private int _maxCoinQuantity = 3;
    [SerializeField] private int _coinCount;

    void Start()
    {
        Coin._onTake.AddListener(RemoveCoin);

        _coinSpawnDots = GetComponentsInChildren<CoinDot>();
        _coinCount = 0;
    }

    void Update()
    {
        if (_coinCount < _maxCoinQuantity&&_coinCount<_coinSpawnDots.Length)
        {
            SpawnCoin();
        }
    }

    private void SpawnCoin()
    {
        bool isSpawned = false;
        int dotNumber;

        while (!isSpawned)
        {
            dotNumber = Random.Range(0, _coinSpawnDots.Length);

            if (_coinSpawnDots[dotNumber].GetComponentInChildren<Coin>() == null)
            {
                Instantiate(coin, _coinSpawnDots[dotNumber].transform);
                _coinCount++;
                isSpawned = true;
            }
        }
    }

    private void RemoveCoin()
    {
        _coinCount--;
    }
}