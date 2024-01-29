using UnityEngine;

public class OpenClosePanel : MonoBehaviour
{
    [SerializeField] GameObject openPanel, closePanel;
    [SerializeField] private AudioSource audioSource;

    public void Open()
    {
        openPanel.SetActive(true);
    }

    public void Ñlose()
    {
        closePanel.SetActive(false);
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(audioSource.clip);
    }
}
