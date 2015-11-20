using UnityEngine;
using System.Collections;

public class tileMaterialPicker : MonoBehaviour {

    [SerializeField]
    int mat;
    float timer = 0;
    public enum TileType
    {
        basic,
        cardinal,
        diagional,
        pillar,
    };
    [System.NonSerialized]
    /// <summary>
    /// Variable that affects what kind of material swap is done
    /// It is hidden in inspector, because it should sync with the
    /// tile's type instead of having us set it manually
    /// </summary>
    public TileType Type;
    public bool on;
    public float timeToChange;

    #region basic tile properties
    /*[System.Serializable]
    class Materials : System.Object
    {*/
        //[System.Serializable]
        [SerializeField]
        Material tile00;
        [SerializeField]
        Material tile01;
        [SerializeField]
        Material tile02;
        [SerializeField]
        Material tile03;
        [SerializeField]
        Material tile04;
        [SerializeField]
        Material tile05;
        [SerializeField]
        Material tile06;
        [SerializeField]
        Material tile07;
        [SerializeField]
        Material tile08;
        [SerializeField]
        Material tile09;
        [SerializeField]
        Material tile10;
        [SerializeField]
        Material tile11;
    //}
    #endregion


    // Use this for initialization
	void Start () {
        mat = 0;
        if (this.GetComponent<Tile>() != null)
        {
            //Debug.Log("Found tile Component");
            Type = (TileType)this.GetComponent<Tile>().Type;
        }
        /*else
        {
            Debug.Log("Did not find tile Component");
        }*/
	}
	
	// Update is called once per frame
	void Update () {
        if(!on)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer > timeToChange)
        {
            mat += 1;
            //skip starting white
            if (mat > 11) mat = 1;

            timer = 0;
        }

        MeshRenderer renderer = GetComponent<MeshRenderer>();

        #region pick material
        //There has to be a better way... 
        //Like how in JS you can have '"tile" + mat'
        switch (mat)
        {
            case 0:
                {
                    renderer.material = tile00;
                    break;
                }
            case 1:
                {
                    renderer.material = tile01;
                    break;
                }
            case 2:
                {
                    renderer.material = tile02;
                    break;
                }
            case 3:
                {
                    renderer.material = tile03;
                    break;
                }
            case 4:
                {
                    renderer.material = tile04;
                    break;
                }
            case 5:
                {
                    renderer.material = tile05;
                    break;
                }
            case 6:
                {
                    renderer.material = tile06;
                    break;
                }
            case 7:
                {
                    renderer.material = tile07;
                    break;
                }
            case 8:
                {
                    renderer.material = tile08;
                    break;
                }
            case 9:
                {
                    renderer.material = tile09;
                    break;
                }
            case 10:
                {
                    renderer.material = tile10;
                    break;
                }
            case 11:
                {
                    renderer.material = tile11;
                    break;
                }
            default:
                break;
        }
        #endregion


    }
}
