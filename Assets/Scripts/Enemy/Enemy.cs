using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public void Die()
    {
        gameObject.SetActive(false);
    }
}
