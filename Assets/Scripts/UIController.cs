using UnityEngine;

public class UIController : MonoBehaviour
{
    private ManHanging _manHanging;
    // Start is called before the first frame update
    void Start()
    {
        _manHanging = FindObjectOfType<ManHanging>();
    }

    public void ResetGame()
    {
        _manHanging._panelWon.SetActive(false);
        _manHanging._panelGameOver.SetActive(false);
        _manHanging.ResetGame();  
    }
}
