using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCPI : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider HealthBar;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    public float currentCPI;
    public float maxCPI;
    void Start()
    {
        maxCPI = 10f;
        currentCPI = 7.0f;
        HealthBar.value = currentCPI;
        HealthBar.image.color = Color.Lerp(MinHealthColor, MaxHealthColor, currentCPI / maxCPI);
    }
    
    // Update is called once per frame
    public void changeCPI(float change)
    {
        currentCPI += change;
        HealthBar.value = currentCPI;
        HealthBar.image.color = Color.Lerp(MinHealthColor, MaxHealthColor, currentCPI / maxCPI);
    }

    private void Update()
    {
        
    }
}
