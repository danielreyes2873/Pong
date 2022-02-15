using UnityEngine;

public class BallSpeedPowerUp : MonoBehaviour
{
    public float speed = 5f;

    public float height = 0.5f;

    private Vector3 pos;
    
    // I realize that movement of the powerups could have been done in one
    // class but I originally intended to do more than just move the pellets
    // with these classes. That didn't work out. If I was to optimize this 
    // code, condensing these classes into one is probably where I'd start.
    
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        pos = new Vector3(0f, 0.21f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        float newZ = -Mathf.Cos(Time.time * speed) * height + pos.z;
        transform.position = new Vector3(0f,transform.position.y, newZ);
    }
}