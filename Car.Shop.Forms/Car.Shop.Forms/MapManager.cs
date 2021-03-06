﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace Car.Shop.Forms
{
    public class MapManager
    {
        public static Position GetXamPosition(Plugin.Geolocator.Abstractions.Position position)
            => new Position(position.Latitude, position.Longitude);

        public Map GetMap(bool CurrentPosition, Position position, Circle circle = null, List<Pin> pins = null)
        {
            var mapSpam = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(30));
            var map = new Map(mapSpam);
            map.IsShowingUser = CurrentPosition;

            if (circle != null)
                map.MapElements.Add(circle);

            if (pins != null)
                pins.ForEach(x => map.Pins.Add(x));

            return map;


        }

    }
}
