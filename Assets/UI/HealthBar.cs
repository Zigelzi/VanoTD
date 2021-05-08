using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Gradient healthGradient;
    Slider healthSlider;
    Image healthBarImage;

    void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthBarImage = transform.Find("Bar").GetComponent<Image>();
    }

    public void SetMaxHealth(int maxHealth)
    {
        healthSlider = GetComponent<Slider>();
        healthBarImage = transform.Find("Bar").GetComponent<Image>();

        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        healthBarImage.color = healthGradient.Evaluate(1f);
    }

    public void UpdateHealth(int health)
    {
        healthSlider.value = health;
        healthBarImage.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
