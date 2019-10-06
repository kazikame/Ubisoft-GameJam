using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject player1;
	public GameObject player2;
    public GameObject gameover1;
    public GameObject gameover2;
    void Start()
    {
        gameover1.SetActive(false);
        gameover2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		if (player1.GetComponent<PlayerCPI>().currentCPI >= 10f || player2.GetComponent<PlayerCPI>().currentCPI <= 0f)
		{
            gameover1.SetActive(true);
            player1.GetComponent<Player_status>().lockControls = true;
            player2.GetComponent<Player_status>().lockControls = true;
        }
		if (player2.GetComponent<PlayerCPI>().currentCPI >= 10f || player1.GetComponent<PlayerCPI>().currentCPI <= 0f)
		{
            gameover2.SetActive(true);
            player1.GetComponent<Player_status>().lockControls = true;
            player2.GetComponent<Player_status>().lockControls = true;
        }
	}
}
