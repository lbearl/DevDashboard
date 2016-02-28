/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var DashboardController = (function () {
            function DashboardController($scope, $location, $http, serverService) {
                //forcibly injecting the servers into the scope for now
                this.$scope = $scope;
                this.$location = $location;
                this.$http = $http;
                this.serverService = serverService;
                $http({
                    method: 'Post',
                    url: '/api/ServerActions/Servers'
                }).then(function (response) {
                    //success
                    $scope.servers = response.data;
                }, function (response) {
                    //fail
                });
                $http({
                    method: 'GET',
                    url: '/api/UserDashboard/GetJiraHighPriorityIssues'
                }).then(function (response) {
                    $scope.issues = response.data;
                }), function (respose) {
                    //handle the fail case
                };
            }
            DashboardController.$inject = [
                '$scope',
                '$location',
                '$http',
                'ServerService'
            ];
            return DashboardController;
        })();
        Controllers.DashboardController = DashboardController;
        angular.module('dashboard').controller('dashboardController', ['$scope', '$location', '$http', 'ServerService', DashboardController]);
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardController.js.map