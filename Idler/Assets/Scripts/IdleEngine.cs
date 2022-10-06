using System.Collections;
using System.Collections.Generic;
using IdleGame;
using UnityEngine;

public class IdleEngine : MonoBehaviour
{
    void Update()
    {
        GameManager.instance.Tick(Time.deltaTime);
    }
}
