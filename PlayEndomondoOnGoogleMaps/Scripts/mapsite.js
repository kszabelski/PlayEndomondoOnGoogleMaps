var map;
function initMap() {
    map = new google.maps.Map(document.getElementById('map'), {
        zoom: 3,
        center: { lat: 0, lng: 0 },
        mapTypeId: google.maps.MapTypeId.TERRAIN
    });

    $("#btnCenter").click(function() {
        map.setZoom(parseInt($("#inputZoom").val()));
        map.setCenter(coords[0]);
    });

    $("#btnDraw").click(function () {
        if (!coords) {
            return;
        }

        function createTimeoutCall(i) {
            return function () {
                var path = new google.maps.Polyline({
                    path: [coords[i], coords[i + 1]],
                    geodesic: true,
                    strokeColor: '#FF0000',
                    strokeOpacity: 1.0,
                    strokeWeight: 2
                });

                path.setMap(map);
            }
        }

        for (var i = 0; i < coords.length; i++) {
            window.setTimeout(createTimeoutCall(i), i * 50)
        }
    });
}