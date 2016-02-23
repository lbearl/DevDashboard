﻿module Dashboard {
    'use strict';
    class Routes {
        static $inject = ["$routeProvider"];

        constructor($routeProvider: ng.route.IRouteProvider) {
            $routeProvider
                .when("/server/:serverid", {
                    templateUrl: "/Scripts/dashboard-app/views/server.html",
                    controller: "dashboardController",
                    controllerAs: "vm"
                })
                .when("/index", {
                    templateUrl: "/Scripts/dashboard-app/views/index.html",
                    controller: "dashboardController",
                    controllerAs: "vm"
                })
                .otherwise({
                    redirectTo: "/index"
                });
        }
    }


    var dashboard = angular.module('dashboard', ["ngRoute", "angular-flot"])
        .config(Routes);
}
