module Dashboard {
    'use strict';
    class Routes {
        static $inject = ["$routeProvider"];

        constructor($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when("/server/:serverid", {
                    templateUrl: "/Scripts/dashboard-app/views/_server.html",
                    controller: "dashboardController",
                    controllerAs: "vm"
                })
                .when("/index", {
                    templateUrl: "/Scripts/dashboard-app/views/_dashboard.html",
                    controller: "dashboardController",
                    controllerAs: "vm"
                })
                .otherwise({
                    redirectTo: "/index"
                });
        }
    }


    var dashboard = angular.module('dashboard', ["ngRoute", "nvd3"])
        .config(Routes);
}

