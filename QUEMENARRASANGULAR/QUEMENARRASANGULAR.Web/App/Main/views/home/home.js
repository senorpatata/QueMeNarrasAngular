(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', function ($scope, uiGmapGoogleMapApi) {
            var vm = this;
            //Home logic...


            $scope.tuits = [];
            $scope.markers = [];
            $scope.thaMap = null;
            $scope.erroresAngular = "";

            /* INICIALMENTE */

            $scope.map = {

                zoom: 14,
                options: {
                    scrollwheel: true,

                },
                control: {}
                ,
                events: {

                    idle: function (map) {
                        $scope.$apply(function () {
                            console.log("idle;")
                            GetTuits();
                            PaintTuits();
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

                    $scope.erroresAngular = "Cogida geolocalizacion";

                    $scope.$apply(function () {

                        $scope.erroresAngular = position.coords.latitude;
                        $scope.map.center.latitude = position.coords.latitude;
                        $scope.map.center.longitude = position.coords.longitude;
                    });

                }, errorPosition, optionsLocation);
            }


            GetTuits();
            PaintTuits();

            function GetTuits()
            {
                //Obtener del mapa, coordenadas, ancho, etc, pasárselo al servicio

                if (typeof ($scope.map) != "undefined" && typeof ($scope.map.center) != "undefined")
                {
                    var latylong = $scope.map.center.latitude + " " + $scope.map.center.longitude;
                    var nivelZoom = $scope.map.zoom;

                    var llamada = abp.services.app.fool.getTuits($scope.map.center.longitude, $scope.map.center.latitude, $scope.map.zoom);
                    llamada.promise()
                    .then(function (response) {
                        $scope.$apply(function () {
                            $scope.tuits = response.data;
                            console.debug("Petición ok");
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

            function PaintTuits()
            {
                //De la lista de tuis, pintar

            }





        }
    ]);
})();