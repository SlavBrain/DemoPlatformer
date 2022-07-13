using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] public static UnityEvent _onTake = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _onTake?.Invoke();
            Destroing();
            Debug.Log("Взял");
        }
    }

    private void Destroing()
    {
        Destroy(gameObject);
    }
    
}
