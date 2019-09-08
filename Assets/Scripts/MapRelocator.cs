namespace Mapbox.Examples
{
    using UnityEngine;
    using Mapbox.Unity.Location;
    using Mapbox.Unity.Map;
    using UnityEngine.UI;

    public class MapRelocator : MonoBehaviour {
        public AbstractMap map;

        void Update() {
            var location = LocationProviderFactory.Instance.DefaultLocationProvider.CurrentLocation;
            map.UpdateMap(location.LatitudeLongitude,map.AbsoluteZoom);
        }
    }
}