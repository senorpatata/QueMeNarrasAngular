(function () {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', function ($scope, uiGmapGoogleMapApi) {
            var vm = this;
            //Home logic...




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
                    center_changed: function (map) {
                        $scope.$apply(function () {
                            console.log("cambio de center;")
                        });
                    },
                    zoom_changed: function (map) {
                        $scope.$apply(function () {
                            console.log("cambio de centezoomr;")
                        });
                    }
                }
            };
            $scope.marker = [];

            uiGmapGoogleMapApi.then(function (maps) {

                console.log("Listo, empezamos geo");

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


        }
    ]);
})();