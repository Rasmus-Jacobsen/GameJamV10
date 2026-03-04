using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 200;
    public int attackPower = 30;

    void Start()
    {
        Player player = FindAnyObjectByType<Player>();
        if (player != null)
        {
            player.StartTurn();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
