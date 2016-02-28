/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
module Dashboard.Controllers {
    import Server = Models.Server;
    import DashboardScope = Interfaces.IDashboardScope;
    import ServerService = Dashboard.Services.ServerService;
    "use strict";

    export class DashboardController {
        private servers: Server[];

        public static $inject = [
            '$scope',
            '$location',
            '$http',
            'ServerService'
        ];

        constructor(
            private $scope: DashboardScope,
            private $location: ng.ILocationService,
            private $http: ng.IHttpService,
            private serverService: ServerService) {
            //forcibly injecting the servers into the scope for now

            $scope.servers = serverResource.query();

            $http({
                method: 'GET',
                url: '/api/UserDashboard/GetJiraHighPriorityIssues'
            }).then(response => {
                $scope.issues = response.data;
            }), respose => {
                //handle the fail case
            }
        }
    }

    angular.module('dashboard').controller('dashboardController', ['$scope', '$location', '$http', 'ServerService', DashboardController]);
}