using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveGround : MonoBehaviour
{
    Vector3 groundPos;
    [SerializeField] Camera mainCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        groundPos = transform.position;
        groundPos.x = mainCam.transform.position.x;
        transform.position = groundPos;
    }
}
