

(function () {
    angular.module('quemenarras.services', ['quemenarras.constants'])
            .service("servicios", ["$http", "Settings", function ($http, Settings) {


                this.localizationSHORT = "IndicadoresAbreviado";

                function ObjecttoParams(obj) {
                    var p = [];
                    for (var key in obj) {
                        p.push(key + '=' + encodeURIComponent(obj[key]));
                    }
                    return p.join('&');
                }
                ;
                // Login
                this.login = function (user) {
                    return $http({
                        method: 'POST',
                        url: Settings.login,
                        data: ObjecttoParams(user),
                        headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
                    });
                };

                this.GetLocalized = function (local) {
                    try {
                        if (local != undefined && local != '') {
                            return abp.localization.localize(local);
                        }
                        return '';
                    }
                    catch (err) {
                        console.error(err);
                        return local;
                    }
                }


            }])



})();

