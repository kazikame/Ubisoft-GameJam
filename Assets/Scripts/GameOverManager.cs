using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject player1;
	public GameObject player2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (player1.GetComponent<PlayerCPI>().currentCPI >= 10f || player2.GetComponent<PlayerCPI>().currentCPI <= 0f)
		{
			SceneManager.LoadScene("scenep1");
		}
		if (player2.GetComponent<PlayerCPI>().currentCPI >= 10f || player1.GetComponent<PlayerCPI>().currentCPI <= 0f)
		{
			SceneManager.LoadScene("scenep2");
		}
	}
}
