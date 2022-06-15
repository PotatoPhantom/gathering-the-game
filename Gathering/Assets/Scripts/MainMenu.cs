using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject connectPanel;

    public static string address;
    public static string port;

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void HidePanel()
    {
        connectPanel.SetActive(false);
    }

    public void TogglePanel()
    {
        connectPanel.SetActive(!connectPanel.activeSelf);
    }
}
