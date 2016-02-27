/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
module Dashboard.Controllers {
    import Server = Models.Server;
    import DashboardScope = Interfaces.IDashboardScope;
    "use strict";

    export class DashboardController {
        private servers: Server[];

        public static $inject = [
            '$scope',
            '$location',
            '$http'
        ];

        constructor(
            private $scope: DashboardScope,
            private $location: ng.ILocationService,
            private $http: ng.IHttpService) {
            //forcibly injecting the servers into the scope for now

            $http({
                method: 'Post',
                url: '/api/ServerActions/GetAllServers'
            }).then(response => {
                //success
                $scope.servers = response.data;

            }, response => {
                //fail
            });
        }
    }

    angular.module('dashboard').controller('dashboardController', ['$scope', '$location', '$http', DashboardController]);
}