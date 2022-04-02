using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] GameObject statusBox;
    [SerializeField] HPBar hpBar;

    [SerializeField] Color psnColor;
    [SerializeField] Color brnColor;
    [SerializeField] Color slpColor;
    [SerializeField] Color parColor;
    [SerializeField] Color frzColor;

    Pokemon _pokemon;

    Dictionary<ConditionID, Color> statusColors;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = _pokemon.Base.Name;
        levelText.text = "Lvl " + _pokemon.Level;
        hpBar.SetHP((float) _pokemon.HP / _pokemon.MaxHP);

        statusColors = new Dictionary<ConditionID, Color>()
        {
            { ConditionID.psn, psnColor},
            { ConditionID.brn, brnColor},
            { ConditionID.slp, slpColor},
            { ConditionID.par, parColor},
            { ConditionID.frz, frzColor},
        };


        SetStatus();
        _pokemon.OnStatusChanged += SetStatus;
    }

    public void SetStatus()
    {
        if(_pokemon.Status == null)
        {
            statusBox.SetActive(false);
        }
        else
        {
            statusBox.SetActive(true);
            Text statusText = statusBox.GetComponentInChildren<Text>();
            statusText.text = _pokemon.Status.Id.ToString().ToUpper();
            statusBox.GetComponent<Image>().color = statusColors[_pokemon.Status.Id];
        }
    }

    public IEnumerator UpdateHP()
    {
        if(_pokemon.HPChanged)
        {
            yield return hpBar.SetHPSmooth((float) _pokemon.HP / _pokemon.MaxHP);
            _pokemon.HPChanged = false;
        }
    }
}
