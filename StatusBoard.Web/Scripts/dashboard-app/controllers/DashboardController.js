/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var DashboardController = (function () {
            function DashboardController($scope, $location, $http, serverService) {
                this.$scope = $scope;
                this.$location = $location;
                this.$http = $http;
                this.serverService = serverService;
                //a few notes on the next line of code as it does quite a bit: 
                //  1) It uses ng-resource behind the scenes, but is abstracted away through a ResourceBuilder object
                //  2) $resource + typescript is the opposite of a match made in heaven (see the interfaces directory for why)
                $scope.servers = serverService.getServers();
                $http({
                    method: "GET",
                    url: "/api/UserDashboard/GetJiraHighPriorityIssues"
                }).then(function (response) {
                    $scope.issues = response.data;
                });
            }
            DashboardController.$inject = [
                "$scope",
                "$location",
                "$http",
                "ServerService"
            ];
            return DashboardController;
        })();
        Controllers.DashboardController = DashboardController;
        angular.module("dashboard").controller("dashboardController", ["$scope", "$location", "$http", "ServerService", DashboardController]);
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardController.js.map