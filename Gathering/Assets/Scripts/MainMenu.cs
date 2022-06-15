using Unity.Netcode;
using Unity.Netcode.Transports.UNET;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Canvas canvas;
    public GameObject connectPanel;

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
        NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectAddress = input;
    }

    public void onPortChange(string input)
    {
        if (int.TryParse(input, out int port))
            NetworkManager.Singleton.GetComponent<UNetTransport>().ConnectPort = port;
    }
}
