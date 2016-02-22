//module Dashboard {
//    'use strict';

//    class Routes {
//        static $inject = ["$routeProvider"];

//        constructor($routeProvider: ng.route.IRouteProvider) {
//            $routeProvider
//                .when("/server/:serverid", {
//                    templateUrl: "/views/server.html",
//                    controller: "DashboardController",
//                    controllerAs: "vm"
//                })
//                .when("/index", {
//                    templateUrl: "/views/index.html",
//                    controller: "DashboardController",
//                    controllerAs: "vm"
//                })
//                .otherwise({
//                    redirectTo: "/index"
//                });
//        }
//    }

//    angular.module("dashboard").config(Routes);
//}