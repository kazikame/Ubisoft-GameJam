using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    public Slider HealthBar1;
    public Slider HealthBar2;

    void Awake()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();
        Instantiate(HealthBar1, new Vector3(15f, 10f, 0f), Quaternion.identity, transform);
        Instantiate(HealthBar2, new Vector3(objectRectTransform.rect.width-175f, 10f, 0f), Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {

        var player1 = Player1.GetComponent<PlayerCPI>();
        HealthBar1.value = player1.HealthBar.value;
        var player2 = Player2.GetComponent<PlayerCPI>();
        HealthBar2.value = player2.HealthBar.value;
        //Destroy(HealthBar1);
        //Destroy(HealthBar2);
        //RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();
        //Instantiate(HealthBar1, new Vector3(15f, 10f, 0f), Quaternion.identity, transform);
        //Instantiate(HealthBar2, new Vector3(objectRectTransform.rect.width - 175f, 10f, 0f), Quaternion.identity, transform);
    }
}
