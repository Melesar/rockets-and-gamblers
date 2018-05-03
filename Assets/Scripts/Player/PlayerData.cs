using System.Threading.Tasks;
using Framework.Data;
using UnityEngine;

namespace RocketsAndGamblers.Player
{
    [CreateAssetMenu(menuName = "R&G/Player data")]
    public class PlayerData : PersistantScriptableObject
    {
        //TODO Return actual player id
        public int Id => Constants.PlayerId;

        [SerializeField, HideInInspector] private int id;

        public async Task Init()
        {
            //Grab device id

            //Find if one exists in the database

            //Get existing player or create a new one

            //Populate id

            //Pretend we are initalizing player from cloud
            await new WaitForSeconds(2f);
        }

        protected override void OnEnable()
        {
            Debug.Log("Player data enabled");
            base.OnEnable();
        }

        protected override void OnDisable()
        {
            Debug.Log("Player data disabled");
            base.OnDisable();
        }
    }
}