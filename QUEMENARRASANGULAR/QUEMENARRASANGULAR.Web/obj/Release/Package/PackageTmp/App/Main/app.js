(function () {
    'use strict';

    var app = angular.module('app', [
        'ngAnimate',
        'ngSanitize',
        'ngTouch',
        'ui.router',
        'ui.bootstrap',
        'ui.jq',
        'abp',
        'quemenarras.constants',
        'quemenarras.services',
        'quemenarras.filters',
        'dx',
        'uiGmapgoogle-maps'
    ]);

    //Configuration for Angular UI routing.
    app.config([
        '$stateProvider', '$urlRouterProvider',
        function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/');
            $stateProvider
                .state('home', {
                    url: '/',
                    templateUrl: '/App/Main/views/home/home.cshtml',
                    menu: 'Home' //Matches to name of 'Home' menu in QUEMENARRASANGULARNavigationProvider
                })
                .state('about', {
                    url: '/about',
                    templateUrl: '/App/Main/views/about/about.cshtml',
                    menu: 'About' //Matches to name of 'About' menu in QUEMENARRASANGULARNavigationProvider
                });
        }
    ]);
    //config gmaps
    app.config(function(uiGmapGoogleMapApiProvider) {
        uiGmapGoogleMapApiProvider.configure({
            key: 'AIzaSyBalzAcPhT0kUYhp3gjeB7_vRpxxW4fPdk', //    key: 'your api key',
            v: '3', //defaults to latest 3.X anyhow
            libraries: 'weather,geometry,visualization'
        });
    })
})();