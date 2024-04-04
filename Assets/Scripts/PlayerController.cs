using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    public Rigidbody rb;
    public Animator ani;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();        
        ani = gameObject.GetComponent<Animator>();
    }

    

    void Update()
    {
        
    }
}
