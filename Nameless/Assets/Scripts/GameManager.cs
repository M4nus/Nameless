using UnityEngine;
using System.Collections; 
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GameSpace
{
    public enum GameState
    {
        Research,
        BreakIn,
        Ending
    }

    #region GameManager
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance = null;

        void Awake()
        {
            if(instance == null)
                instance = this;
            else if(instance == this)
                Destroy(gameObject);

            DontDestroyOnLoad(this);
        }
                                 
        // PLAYER                
        public GameObject player;
        public float playerSpeed;
        public string[] weapons;
        public int ammo;
        public int maxAmmo; //prob depends on a weapon

        // AI
        // enum of state
        // enum of enemy type 
        
        // GAME
        public float timeResearch;
        public float timeBreakIn;
        public GameState gameState;

        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public IEnumerator CoroutineUpdate()
        {
            yield return null;
        }


    }
    #endregion

    #region CustomInspector     
#if UNITY_EDITOR

    [CustomEditor(typeof(GameManager))]
    public class CustomInspector : Editor
    {
        private GameManager gm; 

        private void OnEnable()
        {
            gm = target as GameManager;
        }

        public override void OnInspectorGUI()
        {                                    
            EditorGUILayout.LabelField("PLAYER", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            gm.playerSpeed = EditorGUILayout.FloatField("Player speed", gm.playerSpeed);

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("AI", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
                                                                                                

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("GAME", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            

            EditorGUI.indentLevel--;
            EditorGUILayout.Space();   
        }
    }
#endif
#endregion

}
