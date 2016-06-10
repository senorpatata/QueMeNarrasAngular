(function () {
    angular.module('quemenarras.filters', [])
            .filter('nullMessageFilter', function () {
                return function (input) {
                    if (input == null) {
                        return abp.localization.localize('DatoNoDisponible');
                    }
                    return input;
                }
            })
            .filter('localeFilter', function () {

                return function (input) {
                    //Model indica que si es short, tiramos de abreviado
                    if (input != undefined && input != null) {
                        return abp.localization.localize(input);
                    }
                }

            })
            .filter('setDecimal', function ($filter) {
                return function (input, places) {

                    if (input == null) return null;
                    if (isNaN(input)) return input;

                    return parseFloat((input).toFixed(places))

                };
            });




})();
