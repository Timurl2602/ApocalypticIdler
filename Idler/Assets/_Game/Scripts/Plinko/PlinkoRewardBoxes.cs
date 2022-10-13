using System;
using IdleGame;
using UnityEngine;

public class PlinkoRewardBoxes : MonoBehaviour
{
    [SerializeField] private float _multiplier;
    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Transform _plinkoBoard;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Ball"))
        {
            var currentMoney = GameManager.Instance.Money;
            GameManager.Instance.Money = currentMoney * _multiplier;
            GameManager.Instance.PlinkoCanBePlayed = false;
            Debug.Log("it worked");
            Debug.Log(_multiplier);
            Destroy(other);
            var newBall = Instantiate(_ballPrefab, new Vector3(0, (float)6, 0), Quaternion.identity);
            newBall.transform.SetParent(_plinkoBoard); 
        }
    }
}
