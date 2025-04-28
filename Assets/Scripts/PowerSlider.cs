using UnityEngine;
using UnityEngine.UI;

public class PowerSlider : MonoBehaviour
{
    public Slider power;
    bool powerState;
    [SerializeField] private float meterSpeed = 0.1f;
    [SerializeField] private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created1
    void Start()
    {
        power = GetComponent<Slider>();
        power.value = power.minValue;
        powerState = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.moveFlg == 1)
        {
            power = GetComponent<Slider>();
            if (powerState == false)
            {
                power.value += meterSpeed;

                if (power.value == power.maxValue)
                {
                    powerState = true;
                }
            }
            else if(powerState == true)
            {
                power.value -= meterSpeed;

                if (power.value == power.minValue)
                {
                    powerState = false;
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                gameManager.moveFlg = 2;
            }
        }
    }
}
