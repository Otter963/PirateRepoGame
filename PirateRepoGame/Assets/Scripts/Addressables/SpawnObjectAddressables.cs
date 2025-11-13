using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;


//the below is to make custom types of file types
[System.Serializable]
public class AssetReferenceAudioClip : AssetReferenceT<AudioClip>
{
    public AssetReferenceAudioClip(string guid) : base(guid) { }
}

public class SpawnObjectAddressables : MonoBehaviour
{
    [SerializeField] private AssetReference assetReference;
    [SerializeField] private AssetReferenceGameObject assetReferenceGameObject;
    [SerializeField] private AssetReferenceAudioClip assetReferenceAudioClip;
    [SerializeField] private AssetLabelReference assetLabelReference;

    //this is to despawn a game object
    private GameObject spawnedGameObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //this is a reference for when unloading
            //this will be useful with trigger colliders in one scene
            //assetReferenceGameObject.InstantiateAsync().Completed += (asyncOperation) => spawnedGameObject = asyncOperation.Result;

            //the below is for loading just a specific game object

            assetReferenceGameObject.LoadAssetAsync<GameObject>().Completed +=
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperationHandle.Result);
                    }
                    else
                    {
                        Debug.Log("Failed to load");
                    }
                };

            //The below is for objects with a label reference in the addressables menu
            /*
            Addressables.LoadAssetAsync<GameObject>(assetLabelReference).Completed += 
                (asyncOperationHandle) =>
                {
                    if (asyncOperationHandle.Status == AsyncOperationStatus.Succeeded)
                    {
                        Instantiate(asyncOperationHandle.Result);
                    }
                    else
                    {
                        Debug.Log("Failed to load");
                    }
                };
            */
        }

        /*
        if (Input.GetKeyDown(KeyCode.U))
        {
            //this will be useful with trigger colliders in one scene
            //assetReferenceGameObject.ReleaseInstance(spawnedGameObject);
            //when loading a scene, it automatically releases the instances from the previous scene
            /*
            SceneManager.LoadScene("LevelOne");            
        }
        */
    }
}
