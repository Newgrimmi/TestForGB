using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class UpgradeBehavior : MonoBehaviour
{
    [SerializeField] private PauseActivator _pause;
    [SerializeField] private Spells[] _allSpells;
    [SerializeField] private GameObject[] _skillScreen;
    [SerializeField] private TextMeshProUGUI[] _skillScreenText;
    [SerializeField] private Button[] _skillScreenButton;
    [SerializeField] private TextMeshProUGUI[] _skillScreenLevelText;
    [SerializeField] private TextMeshProUGUI[] _skillScreenNameText;

    private List<Spells> _spellsForDrop = new List<Spells>();

    private void Start()
    {
        StartCoroutine(StartGame());
    }

    public void LevelUp()
    {
        _pause.Paused();
        for (int i = 0; i < _allSpells.Length; i++)
        {
            _spellsForDrop.Add(_allSpells[i]);
        }
        for (int i = 0; i < _skillScreen.Length; i++)
        {
            _skillScreen[i].SetActive(true);
            int rnd = Random.Range(0, _spellsForDrop.Count);
            _skillScreenText[i].text = _spellsForDrop[rnd].TakeDescription();
            _skillScreenLevelText[i].text = "Lvl:" + _spellsForDrop[rnd].CurrentSpellLevel.ToString();
            _skillScreenNameText[i].text = _spellsForDrop[rnd].SpellName;
            _skillScreenButton[i].onClick.AddListener(_spellsForDrop[rnd].LevelUp);
            _skillScreenButton[i].onClick.AddListener(EndLevelUp);
            _spellsForDrop.Remove(_spellsForDrop[rnd]);
        }
    }

    public void EndLevelUp()
    {

        for (int i = 0; i < _skillScreen.Length; i++)
        {
            _skillScreen[i].SetActive(false);
            _skillScreenButton[i].onClick.RemoveAllListeners();
        }

        _pause.UnPaused();
    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.05f);
        LevelUp();
    }
}
