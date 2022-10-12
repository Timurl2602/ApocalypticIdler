using IdleGame;
using UnityEngine;

public class PlinkoRewardBoxes : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private GameObject _ball;
    

    private void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            var currentMoney = GameManager.Instance.Money;
                GameManager.Instance.Money = currentMoney * _multiplier;
                Debug.Log("it worked");
                Debug.Log(_multiplier);
                Destroy(_ball);
        }
    }
}
