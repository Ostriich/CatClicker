using TMPro;
using UnityEngine;

public class ClickSpiritBehaviour : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyObject", 1.5f);
    }

    private void FixedUpdate()
    {
        gameObject.transform.position += new Vector3(0, 0.025f, 0);
        gameObject.GetComponent<TextMeshPro>().color -= new Color32(0, 0, 0, 5);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
