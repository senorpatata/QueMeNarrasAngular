(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', function ($scope, uiGmapGoogleMapApi) {
            var vm = this;
            //Home logic...


            $scope.hashTags = [];
            $scope.tuits = [];
            $scope.places = [];
            $scope.thaMap = null;
            $scope.erroresAngular = "";

            /* INICIALMENTE */

            $scope.map = {

                zoom: 14,
                options: {
                    scrollwheel: true

                },
                control: {}
                ,
                markers: [],
                events: {

                    idle: function (map) {
                        $scope.$apply(function () {
                            console.log("idle;");
                            GetTuits();
                           
                          
                        });
                    }
                }
            };
            
         
            uiGmapGoogleMapApi.then(function (maps) {
                lanzarLocation();
            });

            function errorPosition(err) {

                $scope.erroresAngular = "ERROR(" + err.code + '): ' + err.message;
                console.log("No fue bien");
            }


            var lanzarLocation = function () {

                var optionsLocation = {
                    enableHighAccuracy: true,
                    timeout: 10000,
                    maximumAge: 0

                };

                navigator.geolocation.getCurrentPosition(function (position) {

                  

                    $scope.$apply(function () {

                      
                        $scope.map.center.latitude = position.coords.latitude;
                        $scope.map.center.longitude = position.coords.longitude;
                    });

                }, errorPosition, optionsLocation);
            };

            $scope.GetTuit = function(id)
            {
                var result = $.grep($scope.tuits, function (e) { return e.id == id; });
                if (result.length == 0) {
                    // not found
                } else if (result.length == 1) {
                    return result[0];
                } else {
                    // multiple items found
                }
            }
 
            function PaintTuits(tuits) {
                //De la lista de tuis, pintar
                console.log("pintar");
                $scope.map.markers = [];
                $scope.tuits.forEach(function (tuit) {

                    var lat = tuit.latitude, lon = tuit.longitude;
                    var marker = {
                        id: tuit.id,
                        coords: {
                            latitude: lat,
                            longitude: lon
                        }
                    };
                    console.log("Cargando tuit " + tuit.tweetUrl);
                    $scope.map.markers.push(marker);
                    console.log($scope.map.markers);
                   
                });
                $scope.$apply();
            }



            function GetTuits()
            {
                //Obtener del mapa, coordenadas, ancho, etc, pasárselo al servicio

                if (typeof $scope.map != "undefined" && typeof $scope.map.center != "undefined")
                {
                    var latylong = $scope.map.center.latitude + " " + $scope.map.center.longitude;
                    var nivelZoom = $scope.map.zoom;

                    var llamada = abp.services.app.fool.getInformation($scope.map.center.longitude, $scope.map.center.latitude, $scope.map.zoom);
                    llamada.promise()
                    .then(function (response) {

                        $scope.$apply(function () {
                            $scope.tuits = response.tuits;
                            $scope.hashTags = response.hashTags;
                            $scope.places = response.places;
                            PaintTuits();
        
                        });

           
         
                    }//then
                        , function (error) {

                            $scope.$apply(function () {

                                $scope.tuits = [];
                                console.error("Error en la petición: " + error);
                            });
                    });
                }

            }

      

            GetTuits();


        }
    ]);
})();