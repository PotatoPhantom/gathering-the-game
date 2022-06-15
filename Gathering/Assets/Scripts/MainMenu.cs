using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    public GameObject connectPanel;

    public static string address;
    public static string port;

    private void Awake()
    {
        connectPanel.SetActive(false);
    }

    public void Host()
    {
        NetworkManager.Singleton.StartHost();
        canvas.gameObject.SetActive(false);
    }

    public void Join()
    {
        NetworkManager.Singleton.StartClient();
    }

    public void TogglePanel()
    {
        connectPanel.SetActive(!connectPanel.activeSelf);
    }
}
