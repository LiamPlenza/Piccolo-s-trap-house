using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Photon.MonoBehaviour
{
	public PhotonView photonView;
	public Text PlayerNameText;

	private void Awake()
	{
		if (photonView.isMine)
		{
			//PlayerCamera.SetActive(true);
			PlayerNameText.text = PhotonNetwork.playerName;
		}
		else
		{
			PlayerNameText.text = photonView.owner.name;
			PlayerNameText.color = Color.cyan;
		}
	}

	private void Update()
	{
		if (photonView.isMine)
		{
			CheckInput();
		}
	}

	private void CheckInput() //aca hace el coso para mover al wachin de se juego
	{

	}
}