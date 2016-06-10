(function() {
    var controllerId = 'app.views.home';
    angular.module('app').controller(controllerId, [
        '$scope', 'uiGmapGoogleMapApi', function ($scope, uiGmapGoogleMapApi) {
            var vm = this;
            //Home logic...



            $scope.thaMap = null;


            /* INICIALMENTE */

            $scope.map = {
                center: {
                    latitude: 40.454018,
                    longitude: -3.509205
                },
                zoom: 12,
                options: {
                    scrollwheel: false
                },
                control: {}
            };
            $scope.marker = [];
            
  

            uiGmapGoogleMapApi.then(function (maps) {


                $scope.thaMap = maps;
                //maps.map = {
                //    center: {
                //        latitude: 40.454018,
                //        longitude: -3.509205
                //    },
                //    zoom: 12,
                //    options: {
                //        scrollwheel: false
                //    },
                //    control: {}
                //};
                //maps.marker = {
                //    id: 0,
                //    coords: {
                //        latitude: 40.454018,
                //        longitude: -3.509205
                //    },
                //    options: {
                //        draggable: true
                //    }
                //};

            });
         

            navigator.geolocation.getCurrentPosition(function (position) {
                $scope.$apply(function () {
                    $scope.thaMap.Map.latitude = position.coords.latitude;
                    $scope.thaMap.Map.longitude = position.coords.longitude;


                    $scope.map.center.latitude = position.coords.latitude;
                    $scope.map.center.longitude = position.coords.longitude;
                });
            });

        }
    ]);
})();