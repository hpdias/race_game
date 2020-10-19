using UnityEngine;

public class pick : MonoBehaviour
{

    private bool pegou = false;
        
    void OnTriggerEnter()
    {
        if(!pegou){
            pegou = true;
            FindObjectOfType<GameManager>().countPicks();
            Destroy(gameObject);
        }
        
    }
        
}
