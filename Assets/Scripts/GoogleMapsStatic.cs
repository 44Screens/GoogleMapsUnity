using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Google Maps Static documentation: https://developers.google.com/maps/documentation/maps-static/intro
/// </summary>
[RequireComponent(typeof(RawImage))]
public class GoogleMapsStatic : MonoBehaviour
{
    /// <summary>
    /// 0 = address
    /// 1 = zoom
    /// 2 = map width
    /// 3 = map height
    /// 4 = scale
    /// 5 = map type
    /// 6 = api key
    /// Get your api key here : https://developers.google.com/maps/documentation/maps-static/get-api-key
    /// </summary>
    private const string _url = "https://maps.googleapis.com/maps/api/staticmap?center={0}&zoom={1}&size={2}x{3}&scale={4}&maptype={5}&markers=color:red|{0}&key={6}";

    [Header("Static Map Settings")]
    public StaticMap _staticMap;
    public int _mapWidth = 640;
    public int _mapHeight = 640;
    public bool _autoSize = false;
    [Tooltip("Effective only in auto size mode")]
    [Range(1,8)]
    public int _sizeDivider;
    public bool _autoUpdate = false;

    [Header("API Settings")]
    [TextArea(3, 10)]
    public string _key;

    private RawImage _rawImage;

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Start()
    {
        if (!_autoUpdate)
        {
            GenerateMap();
        }
    }

    private void OnEnable()
    {
        if (_autoUpdate)
        {
            GenerateMap();
        }
    }

    public void GenerateMap()
    {
        StartCoroutine(GenerateMapCoroutine());
    }

    private IEnumerator GenerateMapCoroutine()
    {
        string url;
        int width;
        int height;

        if (_autoSize)
        {
            RectTransform rt = _rawImage.GetComponent<RectTransform>();
            width = (int)(rt.rect.width / _sizeDivider);
            height = (int)(rt.rect.height / _sizeDivider);
        }
        else
        {
            width = _mapWidth;
            height = _mapHeight;
        }

        url = string.Format(_url, _staticMap._address, _staticMap._zoom, width, height, _staticMap._scale, _staticMap._type, _key);

        WWW www = new WWW(url);
        yield return www;
        _rawImage.texture = www.texture;
        //_img.SetNativeSize(); // remove this line if you want to keep your image size
        Debug.Log("GoogleMapsStatic:: generate map - size: " + width + "x" + height + " - url: " + url);
    }
}