using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NHR
{
    public class EventType 
    {
        //이벤트들
        public enum eEventType
        {
            NONE = -1, 
            Event_Test,
            Change_Scene,
            CharacterSlot_Active_False, 
            CharacterSlot_Active_True,
            Input_Key, 
            Update_CurvedUI, 
            Clear_TutorialQuest, 
            Notice_EventUI, 
            Notice_Role, 
            Notice_GameResult, 
            Notice_Attacked, 
            Notice_Respawn, 
            Watching_Game, 
            Change_Monster,
            Update_Timer,
            Update_MonsterTimer, 
            Get_Mission
        }
    }

}
