using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
   public void TakeDamage(float damage)
    {
        slider.value -= damage;
    }
    public void SetHealth(float maxHp)
    {
        slider.value = PlayerPrefs.GetFloat("health",maxHp); ;
    }
}
