using UnityEngine;

public class ChipiFlex : MonoBehaviour
{
    [SerializeField] private TapTapPanelBehaviour tapTapPanelBehaviour;
    [SerializeField] private GameObject chipiImage;

    [SerializeField] private AudioClip chipiChapaSong, mainThemeSong;

    private void FixedUpdate()
    {
        if (chipiImage.activeSelf) { chipiImage.transform.Rotate(0,0,5); }
    }

    private void Update()
    {
        // Change components that depend on boost mode
        if(tapTapPanelBehaviour.BoostIsActive && !chipiImage.activeSelf)
        {
            chipiImage.SetActive(true);
            Camera.main.GetComponent<AudioSource>().clip = chipiChapaSong;
            Camera.main.GetComponent<AudioSource>().Play();
        }

        if (!tapTapPanelBehaviour.BoostIsActive && chipiImage.activeSelf)
        {
            chipiImage.SetActive(false);
            Camera.main.GetComponent<AudioSource>().clip = mainThemeSong;
            Camera.main.GetComponent<AudioSource>().Play();
        }
    }
}
