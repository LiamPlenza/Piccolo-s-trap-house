using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private string VersioName = "0.1";
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateInput;
    [SerializeField] private InputField JoinInput;

    [SerializeField] private GameObject StartButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(VersioName);
    }
    private void Start()
    {
        UsernameMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUsernameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUsername()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }

    public void CreateGame()
    {
        //PhotonNetwork.LeaveRoom();
        PhotonNetwork.CreateRoom(CreateInput.text, new RoomOptions() { maxPlayers = 4 }, null);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //OnJoinedGame();
    }
    public void JoinGame()
    {
        //PhotonNetwork.LeaveRoom();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.maxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(JoinInput.text, roomOptions, TypedLobby.Default);
        //SceneManager.LoadScene(1);
        //OnJoinedGame();
    }

    public void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}