/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var DashboardController = (function () {
            function DashboardController($scope, $location, $http) {
                this.$scope = $scope;
                this.$location = $location;
                this.$http = $http;
                //forcibly injecting the servers into the scope for now
                $http({
                    method: 'GET',
                    url: '/api/ServerActions/GetAllServers'
                }).then(function (response) {
                    //success
                    $scope.servers = response.data;
                }, function (response) {
                    //fail
                });
            }
            DashboardController.$inject = [
                '$scope',
                '$location',
                '$http'
            ];
            return DashboardController;
        })();
        Controllers.DashboardController = DashboardController;
        angular.module('dashboard').controller('dashboardController', ['$scope', '$location', '$http', DashboardController]);
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardController.js.map