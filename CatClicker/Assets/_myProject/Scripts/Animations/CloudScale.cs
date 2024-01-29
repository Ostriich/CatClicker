using UnityEngine;

public class CloudScale : MonoBehaviour
{
    [SerializeField] float deltaTime, deltaScale;

    private int multiplier = 1;

    private void Start()
    {
        Invoke("ChangeMultiplier", deltaTime);
    }

    // Animation clouds
    private void FixedUpdate()
    {
        transform.localScale += new Vector3(deltaScale * multiplier , -deltaScale * multiplier , 0);
    }

    // Changes the object's scale vector
    private void ChangeMultiplier()
    {
        multiplier *= -1;
        Invoke("ChangeMultiplier", deltaTime);
    }
}
