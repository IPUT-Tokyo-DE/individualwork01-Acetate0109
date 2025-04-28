using JetBrains.Annotations;
using Mono.Cecil;
using TMPro;
using UnityEditor.Callbacks;
using UnityEngine;

public class CannonFire : MonoBehaviour
{
    [SerializeField] private GameObject fire;
    [SerializeField] private float defaultFireSpeed = 5.0f;
    [SerializeField] private PowerSlider slider;
    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private GameObject mainCam;
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] TextMeshProUGUI textMeshMeter;
    [SerializeField] TextMeshProUGUI resultValue;
    [SerializeField] TextMeshProUGUI resultText;
    [SerializeField] TextMeshProUGUI resultMeterText;
    GameObject spawnFire;
    Rigidbody2D rb;
    bool fireFlg = true;
    Vector3 offset;
    public Vector3 cameraPos;
    float startPos;
    public float finishPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cameraPos.z = -10;
        startPos = cameraPos.x;
        resultValue.enabled = false;
        resultMeterText.enabled = false;
        resultText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.moveFlg == 2)
        {
            Vector2 throwVector = transform.up;
            if (fireFlg == true)
            {
                spawnFire = Instantiate(fire, transform.position, Quaternion.identity);
                rb = spawnFire.GetComponent<Rigidbody2D>();
                offset.x = mainCam.transform.position.x - spawnFire.transform.position.x;
                offset.y = mainCam.transform.position.y - spawnFire.transform.position.y;
                float firePower = slider.power.value * defaultFireSpeed;
                rb.AddForce(throwVector * firePower, ForceMode2D.Impulse);
                fireFlg = false;
            }
            cameraPos.x = spawnFire.transform.position.x + offset.x;
            cameraPos.y = spawnFire.transform.position.y + offset.y;

            mainCam.transform.position = cameraPos;
            finishPos = (cameraPos.x - startPos) * 2.5f;
        }
        if (rb != null && rb.IsSleeping())
        {
            Invoke("DelayMethod", 2.0f);
        }
        textMeshPro.text = finishPos.ToString();
    }
    void DelayMethod()
    {
        textMeshPro.enabled = false;
        textMeshMeter.enabled = false;
        resultValue.enabled = true;
        resultMeterText.enabled = true;
        resultText.enabled = true;
        resultValue.text = finishPos.ToString();
    }
}
