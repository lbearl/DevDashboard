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
                .otherwise({
                redirectTo: "/views/index.html"
            });
        }
        Routes.$inject = ["$routeProvider"];
        return Routes;
    })();
    angular.module("dashboard").config(Routes);
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardRoutes.js.map