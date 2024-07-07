using UnityEngine;
using UnityEngine.UI;

public class ShowArmor : MonoBehaviour
{
    [SerializeField] private Text _headArmor;
    [SerializeField] private Text _bodyArmor;
    [SerializeField] private Player _player;
    [SerializeField] private Image _bodyArmorImage;
    [SerializeField] private Image _headArmorImage;

    private void Start()
    {
        _player.OnHeadArmorChanged += HeadArmorChange;
        _player.OnBodyArmorChanged += BodyArmorChange;

        if (_player.HeadArmorItem != null)
            _headArmorImage.sprite = _player.HeadArmorItem._itemImage;
        if (_player.BodyArmorItem != null)
            _bodyArmorImage.sprite = _player.BodyArmorItem._itemImage;


    }

    private void Update()
    {
        _headArmor.text = _player._headArmor.ToString();
        _bodyArmor.text = _player._body_armor.ToString();
    }

    private void OnDestroy()
    {
        _player.OnBodyArmorChanged -= BodyArmorChange;
        _player.OnHeadArmorChanged -= HeadArmorChange;
    }

    void BodyArmorChange()
    {
        _bodyArmorImage.sprite = _player.BodyArmorItem._itemImage;
    }

    void HeadArmorChange()
    {
        _headArmorImage.sprite = _player.HeadArmorItem._itemImage;
    }
}
