using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MapGen : MonoBehaviour
{

    public Sprite UnexploredRoom;
    public Sprite DefaultRoom;
    public Sprite CurrentRoom;
    public Sprite SecretRoom;
    public Sprite PuzzleRoom;


    void Start()
    {
        Level.UnexploredRoomIcon = UnexploredRoom;
        Level.DefaultRoomIcon = DefaultRoom;
        Level.CurrentRoomIcon = CurrentRoom;
        Level.SecretRoomIcon = SecretRoom;
        Level.PuzzleRoomIcon = PuzzleRoom;

    }

    void DrawRoomOnMap(Sprite s, Vector2 Location)
    {
        GameObject MapTile = new GameObject("MapTile");
        UnityEngine.UI.Image RoomImage = MapTile.AddComponent<UnityEngine.UI.Image>();
        RoomImage.sprite = s;
        RectTransform rectTransform = RoomImage.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(Level.Height, Level.Width) * Level.IconScale;
        rectTransform.position = Location * (Level.IconScale * Level.Height * Level.Scale + (Level.Padding * Level.Height * Level.Scale));
        RoomImage.transform.SetParent(transform, false);

    }
}
