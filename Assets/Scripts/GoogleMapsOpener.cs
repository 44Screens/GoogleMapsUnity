using UnityEngine;

/// <summary>
/// Google Maps Urls documentation: https://developers.google.com/maps/documentation/urls/guide
/// Apple Maps docutmentation: https://developer.apple.com/library/content/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
/// </summary>
public class GoogleMapsOpener : MonoBehaviour
{
    public void OpenLink(string location)
    {
        var url = "";
#if !UNITY_IOS
        url = string.Format("http://maps.google.com/maps?q={0}", location);
#endif

#if UNITY_IOS
        url = string.Format("http://maps.apple.com/?q={0}", location);
#endif

        Application.OpenURL(url);
        Debug.Log("Open link: " + location);
    }

    public void OpenRoute(Route route)
    {
        var url = "";
#if !UNITY_IOS
        url = string.Format("https://www.google.com/maps/dir/?api=1&destination={0}&travelmode={1}", route._destination, route._travelMode);
#endif

#if UNITY_IOS
        //d(by car)
        //w(by foot)
        //r(by public transit)
        var travelMode = "";
        switch (route._travelMode)
        {
            case Enums.TravelMode.driving:
                travelMode = "d";
                break;
            case Enums.TravelMode.walking:
                travelMode = "w";
                break;
            case Enums.TravelMode.transit:
                travelMode = "r";
                break;
            case Enums.TravelMode.bicycling:
            default:
                travelMode = "w";
                break;
        }
        url = string.Format("http://maps.apple.com/?daddr={0}&dirflg={1}", route._destination, travelMode);
#endif

        Application.OpenURL(url);
        Debug.Log("Open route to: " + route._destination + " in " + route._travelMode);
    }
}