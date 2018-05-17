using UnityEngine;

/// <summary>
/// Google Maps Urls documentation: https://developers.google.com/maps/documentation/urls/guide
/// </summary>
public class GoogleMapsOpener : MonoBehaviour
{
    public void OpenLink(string location)
    {
        string url = string.Format("http://maps.google.com/maps?q={0}", location);
        Application.OpenURL(url);
        Debug.Log("Open link: " + location);
    }

    public void OpenRoute(string destination, Enums.TravelMode travelMode)
    {
        string url = string.Format("https://www.google.com/maps/dir/?api=1&destination={0}&travelmode={1}", destination, travelMode);
        Application.OpenURL(url);
        Debug.Log("Open route to: " + destination + " in " + travelMode + " mode");
    }

    public void OpenRoute(Route route)
    {
        string url = string.Format("https://www.google.com/maps/dir/?api=1&destination={0}&travelmode={1}", route.destination, route._travelMode);
        Application.OpenURL(url);
        Debug.Log("Open route to: " + route.destination + " in " + route._travelMode);
    }
}