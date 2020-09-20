using BlazingPizza.ComponentsLibrary.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazingPizza.Shared
{
    public class OrderWithStatus
    {
        public readonly static TimeSpan PreparationDuration = 
            TimeSpan.FromSeconds(20);
        public readonly static TimeSpan DeliveryDuration =
            TimeSpan.FromMinutes(1); // Unrealistic, but more interesting to watch

        public Order Order { get; set; }

        public string StatusText { get; set; }

        public bool IsDelivered { get; set; } // => StatusText == "Delivered";

        public List<Marker> MapMarkers { get; set; }

        public static OrderWithStatus FromOrder(Order order)
        {
            // To simulate a real backend process, we fake status updates based on the amount
            // of time since the order was placed
            string _message;
            bool _isDelivered = false;
            List<Marker> _markers;
            var dispatchTime = order.CreatedTime.Add(PreparationDuration);

            if (DateTime.Now < dispatchTime)
            {
                _message = "Preparando";
                _markers = new List<Marker>
                {
                    ToMapMarker("Usted", order.DeliveryLocation, showPopup: true)
                };
            }
            else if (DateTime.Now < dispatchTime + DeliveryDuration)
            {
                _message = "En ruta a entrega";

                var startPosition = ComputeStartPosition(order);
                var proportionOfDeliveryCompleted = Math.Min(1, (DateTime.Now - dispatchTime).TotalMilliseconds / DeliveryDuration.TotalMilliseconds);
                var driverPosition = LatLong.Interpolate(startPosition, order.DeliveryLocation, proportionOfDeliveryCompleted);
                _markers = new List<Marker>
                {
                    ToMapMarker("Usted", order.DeliveryLocation),
                    ToMapMarker("Repartidor", driverPosition, showPopup: true),
                };
            }
            else
            {
                _message = "Entregado";
                _isDelivered = true;
                _markers = new List<Marker>
                {
                    ToMapMarker("Lugar de entrega", order.DeliveryLocation, showPopup: true),
                };
            }

            return new OrderWithStatus
            {
                Order = order,
                StatusText = _message,
                IsDelivered = _isDelivered,
                MapMarkers = _markers,
            };
        }

        private static LatLong ComputeStartPosition(Order order)
        {
            // Random but deterministic based on order ID
            var random = new Random(order.OrderId);
            var distance = 0.01 + random.NextDouble() * 0.02;
            var angle = random.NextDouble() * Math.PI * 2;
            var offset = (distance * Math.Cos(angle), distance * Math.Sin(angle));
            return new LatLong(
                order.DeliveryLocation.Latitude +
                offset.Item1, order.DeliveryLocation.Longitude + 
                offset.Item2
                );
        }

        static Marker ToMapMarker(string description, 
                            LatLong coords, bool showPopup = false) => 
            new Marker 
            {
                Description = description,
                X = coords.Longitude, 
                Y = coords.Latitude, 
                ShowPopup = showPopup 
            };
    }
}
