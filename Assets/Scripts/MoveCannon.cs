using UnityEngine;

public class MoveCannon : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.moveFlg == 0)
        {
            transform.Rotate(0, 0, -1.0f);
            if (Input.GetMouseButtonDown(0))
            {
                gameManager.moveFlg = 1;
            }     
        }   
    }
}
