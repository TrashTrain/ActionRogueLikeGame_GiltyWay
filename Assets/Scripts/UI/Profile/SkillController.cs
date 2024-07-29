using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using Image = UnityEngine.UI.Image;


public class SkillController : MonoBehaviour
{
    public GameObject skillPrefab;
    public Transform skillPanel;

    public List<Skill> activeSkills = new List<Skill>();
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSkill(Sprite addedSkill, string skillName)
    {
        GameObject newSkill = Instantiate(skillPrefab, skillPanel);
        newSkill.GetComponentInChildren<Image>().sprite = addedSkill;
        
        Skill skill = new Skill
        {
            name = skillName,
            image = addedSkill
        };
        
        activeSkills.Add(skill);
    }

    public class Skill
    {
        public string name;
        public Sprite image;
    }
}
