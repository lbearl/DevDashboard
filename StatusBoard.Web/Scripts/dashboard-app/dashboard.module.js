var Dashboard;
(function (Dashboard) {
    'use strict';
    var Routes = (function () {
        function Routes($routeProvider) {
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
        Routes.$inject = ["$routeProvider"];
        return Routes;
    })();
    var dashboard = angular.module('dashboard', ["ngRoute", "angular-flot"])
        .config(Routes);
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=dashboard.module.js.map