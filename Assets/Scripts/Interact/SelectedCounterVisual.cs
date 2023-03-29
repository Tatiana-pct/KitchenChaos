using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{

    [SerializeField] private ClearCounter _clearCounter;
    [SerializeField] private GameObject _viualGameObject;


    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    #region Player_OnSelectedCounterChanged()
    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e._selectedCounter == _clearCounter)
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
        _viualGameObject.SetActive(true);   
    }
    #endregion

    #region Hide()
    private void Hide()
    {
        _viualGameObject.SetActive(false);
    }
    #endregion
}
