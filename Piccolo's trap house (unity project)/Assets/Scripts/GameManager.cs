using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public GameObject PlayerPrefab;
	public GameObject PiccoloPrefab;
	public GameObject GameCanvas;
	public GameObject SceneCamera;
	public Text PingText;
	public GameObject disconnectUI;
	private bool Off = false;

	public GameObject PlayerFeed;
	public GameObject FeedGrid;

	private void Awake()
	{
		CheckInput();
		GameCanvas.SetActive(true);
	}

	public void Update()
	{
		//PingText.text = "Ping " + PhotonNetwork.GetPing();
	}

	private void CheckInput()
	{
		if (Off && Input.GetKeyDown(KeyCode.Escape))
		{
			disconnectUI.SetActive(false);
			Off = false;
		}
		else if (!Off && Input.GetKeyDown(KeyCode.Escape))
		{
			disconnectUI.SetActive(true);
			Off = true;
		}
	}

	public void SpawnPlayer()
	{
		//float randomValue = Random.Range(-1f, 1f);

		if (PhotonNetwork.playerName == "piccolo") {
			PhotonNetwork.Instantiate(PiccoloPrefab.name, new Vector3(131f, 9f, 122f), Quaternion.identity, 0);
		} else {
			PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(125f, 1f, 20f), Quaternion.identity, 0);
		}
		GameCanvas.SetActive(false);
		SceneCamera.SetActive(false);
	}

	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
		PhotonNetwork.LoadLevel("Menu"); //EN "MENU" VA EL NOMBRE DE LA ESCENA MENU
	}

	private void OnPhotonPlayerConnected(PhotonPlayer player)
	{
		GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
		obj.transform.SetParent(FeedGrid.transform, false);
		obj.GetComponent<Text>().text = player.name + "joined the game";
		obj.GetComponent<Text>().color = Color.green;
	}

	private void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		GameObject obj = Instantiate(PlayerFeed, new Vector2(0, 0), Quaternion.identity);
		obj.transform.SetParent(FeedGrid.transform, false);
		obj.GetComponent<Text>().text = player.name + "left the game";
		obj.GetComponent<Text>().color = Color.red;
	}
}