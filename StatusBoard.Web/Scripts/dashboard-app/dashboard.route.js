var Dashboard;
(function (Dashboard) {
    'use strict';
    var Routes = (function () {
        function Routes($routeProvider) {
            $routeProvider
                .when("/server/:serverid", {
                templateUrl: "/views/server.html",
                controller: "DashboardController",
                controllerAs: "vm"
            })
                .when("/index", {
                templateUrl: "/views/index.html",
                controller: "DashboardController",
                controllerAs: "vm"
            })
                .otherwise({
                redirectTo: "/index"
            });
        }
        Routes.$inject = ["$routeProvider"];
        return Routes;
    })();
    angular.module("dashboard").config(Routes);
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=dashboard.route.js.map