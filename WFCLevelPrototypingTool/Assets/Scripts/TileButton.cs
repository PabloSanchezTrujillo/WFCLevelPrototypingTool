using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    [field: SerializeField] public GameObject ObjectToPlace { get; set; }

    [SerializeField] private GameObject tile;
    [SerializeField] private Color unoccupiedTile;
    [SerializeField] private Color occupiedTile;
    [SerializeField] private AudioClip buildOnTile;
    [SerializeField] private AudioClip clearTile;
    [SerializeField] private GameObject buildingParticles;

    private Tile parentTile;
    private Button tileButton;
    private AudioSource audioSource;

    private void Awake()
    {
        tileButton = GetComponent<Button>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        parentTile = transform.parent.GetComponentInParent<Tile>();
    }

    public void BuildOnTile()
    {
        if(ObjectToPlace == null) { // Clear the tile
            audioSource.volume = 0.7f;
            audioSource.clip = clearTile;
            audioSource.Play();

            parentTile.DeleteObject();
            parentTile.ObjectIndex = 0;
        }
        else { // Build on the tile
            if(!parentTile.Occupied) {
                // Instantiate the new object
                GameObject objectPlaced = Instantiate(ObjectToPlace, tile.transform, false);
                objectPlaced.transform.localPosition = Vector3.zero;

                // Mark the tile as occupied
                parentTile.Occupied = true;

                // Change the tile button's color
                ColorBlock buttonColors = tileButton.colors;
                buttonColors.highlightedColor = occupiedTile;
                tileButton.colors = buttonColors;

                // Play the sound
                audioSource.volume = 0.5f;
                audioSource.clip = buildOnTile;
                audioSource.Play();

                // Instantiate the particles
                Instantiate(buildingParticles, tile.transform.position, tile.transform.rotation);

                // Change the tile's index to the new object index
                BuildingObject buildingObject = ObjectToPlace.GetComponent<BuildingObject>();
                parentTile.ObjectIndex = buildingObject.ObjectIndex;
            }
        }

        // Backtrack the whole grid
        transform.parent.parent.GetComponentInParent<GridGenerator>().BacktrackGrid(parentTile.TileId);
    }

    public void BuildOnTile(GameObject objectToBuild)
    {
        if(!parentTile.Occupied) {
            // Instantiate the new object
            GameObject objectPlaced = Instantiate(objectToBuild, tile.transform, false);
            objectPlaced.transform.localPosition = Vector3.zero;

            // Mark the tile as occupied
            parentTile.Occupied = true;

            // Change the tile button's color
            ColorBlock buttonColors = tileButton.colors;
            buttonColors.highlightedColor = occupiedTile;
            tileButton.colors = buttonColors;

            // Change the tile's index to the new object index
            BuildingObject buildingObject = objectToBuild.GetComponent<BuildingObject>();
            parentTile.ObjectIndex = buildingObject.ObjectIndex;

            //transform.parent.parent.GetComponentInParent<GridGenerator>().LocalBacktrackingGrid(parentTile.TileId, parentTile.ObjectIndex);
        }
    }

    public void ChangeButtonColorToUnoccupied()
    {
        ColorBlock buttonColors = tileButton.colors;
        buttonColors.highlightedColor = unoccupiedTile;
        tileButton.colors = buttonColors;
    }
}