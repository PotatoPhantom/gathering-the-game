using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    public GameObject connectPanel;

    public static string address;
    public static string port;

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        canvas.gameObject.SetActive(false);
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
        canvas.gameObject.SetActive(false);
    }

    public void TogglePanel()
    {
        connectPanel.SetActive(!connectPanel.activeSelf);
    }

    public void onAddressChange(string input)
    {
        address = input;
    }

    public void onPortChange(string input)
    {
        port = input;
    }
}
