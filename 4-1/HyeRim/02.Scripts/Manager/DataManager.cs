using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using Newtonsoft.Json;
public class DataManager
{
    public static readonly DataManager Instance = new DataManager();

    private DataManager() { }

    //데이터들
    private Dictionary<int, CharacterData> dicCharacterData;
    private Dictionary<int, TutorialData> dicTutorialData;
    private Dictionary<string, EventDialogData> dicEventDialogData;

    public int totalTutorialIndex;

    //Json 데이터 로드
    //캐릭터 데이터
    public void LoadCharacterData()
    {
        TextAsset asset = Resources.Load<TextAsset>("Datas/characterData");

        var json = asset.text;
        Debug.LogFormat("<color=red>character data load:{0}</color>", json);

        //역직렬화
        CharacterData[] datas = JsonConvert.DeserializeObject<CharacterData[]>(json);

        this.dicCharacterData = datas.ToDictionary(x => x.id);
        Debug.LogFormat("character data loaded : {0}", this.dicCharacterData);
    }
    //튜토리얼 데이터
    public void LoadTutorialData()
    {
        TextAsset asset = Resources.Load<TextAsset>("Datas/tutorialData");

        var json = asset.text;
        Debug.LogFormat("<color=red>tutorial data load:{0}</color>", json);

        //역직렬화
        TutorialData[] datas = JsonConvert.DeserializeObject<TutorialData[]>(json);

        this.dicTutorialData = datas.ToDictionary(x => x.id);
        Debug.LogFormat("tutorial data loaded : {0}", this.dicTutorialData);

        this.totalTutorialIndex = dicTutorialData.Count;
    }
    //이벤트 dialog 데이터
    public void LoadEventDialogData()
    {
        TextAsset asset = Resources.Load<TextAsset>("Datas/eventDialogData");

        var json = asset.text;
        Debug.LogFormat("<color=red>eventDialog data load:{0}</color>", json);

        //역직렬화
        EventDialogData[] datas = JsonConvert.DeserializeObject<EventDialogData[]>(json);

        this.dicEventDialogData = datas.ToDictionary(x => x.eventType);
        Debug.LogFormat("tutorial data loaded : {0}", this.dicEventDialogData);
    }

    //데이터 제공
    //캐릭터 데이터
    public CharacterData GetCharacterData(int id)
    {
        return this.dicCharacterData[id];
    }
    //튜토리얼 데이터
    public TutorialData GetTutorialData(int id)
    {
        return this.dicTutorialData[id + 100];
    }
    //이벤트 다이얼로그 데이터
    public string GetEventDialog(string eventType)
    {
        return this.dicEventDialogData[eventType].dialog;
    }
}
