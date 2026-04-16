using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private HealthSystemPlayer healthSystem;
    public Slider slider;
    public void Setup(HealthSystemPlayer healthSystem)
    {
        this.healthSystem = healthSystem;
    }
    

    private void Update()
    {
        slider.value = healthSystem.getHealthPercent();
    }
}
