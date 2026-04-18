using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class TMPLinkHandler : MonoBehaviour, IPointerClickHandler
{
    private TMP_Text _textMeshPro;
    private Canvas _canvas;
    private Camera _eventCamera;

    void Awake()
    {
        _textMeshPro = GetComponent<TMP_Text>();
        _canvas = GetComponentInParent<Canvas>();

        // For Screen Space - Overlay, the camera must be null
        if (_canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            _eventCamera = null;
        else
            _eventCamera = _canvas.worldCamera;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Find if a link was clicked at the mouse position
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(_textMeshPro, eventData.position, _eventCamera);

        if (linkIndex != -1) // -1 means no link was clicked
        {
            // Get the link info and open the URL assigned to the <link="ID"> tag
            TMP_LinkInfo linkInfo = _textMeshPro.textInfo.linkInfo[linkIndex];
            string linkId = linkInfo.GetLinkID();
            
            Debug.Log($"Opening Link: {linkId}");
            Application.OpenURL(linkId);
        }
    }
}
