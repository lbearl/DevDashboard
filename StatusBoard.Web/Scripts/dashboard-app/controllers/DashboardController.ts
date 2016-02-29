/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
module Dashboard.Controllers {
    import Server = Models.IServer;
    import DashboardScope = Interfaces.IDashboardScope;
    import ServerResource = Resources.IServerResource;
    import ServerService = Dashboard.Services.ServerService;
    "use strict";

    export class DashboardController {
        private servers: Server[];

        public static $inject = [
            "$scope",
            "$location",
            "$http",
            "ServerService"
        ];

        constructor(
            private $scope: DashboardScope,
            private $location: ng.ILocationService,
            private $http: ng.IHttpService,
            private serverService: ServerService) {

            //a few notes on the next line of code as it does quite a bit: 
            //  1) It uses ng-resource behind the scenes, but is abstracted away through a ResourceBuilder object
            //  2) $resource + typescript is the opposite of a match made in heaven (see the interfaces directory for why)
            $scope.servers = serverService.getServers();

            $http({
                method: "GET",
                url: "/api/UserDashboard/GetJiraHighPriorityIssues"
            }).then(response => {
                $scope.issues = response.data;
            }), respose => {
                //handle the fail case
            }
        }
    }

    angular.module("dashboard").controller("dashboardController", ["$scope", "$location", "$http", "ServerService", DashboardController]);
}