using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnStart : MonoBehaviour, IPointerClickHandler  {
    
    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

}