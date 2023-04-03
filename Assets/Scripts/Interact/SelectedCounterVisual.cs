using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private BaseCounter _baseCounter;
    [SerializeField] private GameObject[] _viualGameObjectArray;


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    #region Player_OnSelectedCounterChanged()
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e._selectedCounter == _baseCounter)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    #endregion

    #region Show()
    private void Show()
    {
        foreach (GameObject visualGameObject in _viualGameObjectArray)
        {

            visualGameObject.SetActive(true);
        }
    }
    #endregion

    #region Hide()
    private void Hide()
    {
        foreach (GameObject visualGameObject in _viualGameObjectArray)
        {

            visualGameObject.SetActive(false);
        }
    }
    #endregion
}
