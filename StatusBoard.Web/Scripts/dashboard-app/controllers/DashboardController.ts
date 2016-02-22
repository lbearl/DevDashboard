/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
module Dashboard.Controllers {
    import Server = Models.Server;
    "use strict";

    export class DashboardController {
        private servers: Server[];

        public static $inject = [
            '$scope',
            '$location'
        ]

        constructor(
            private $scope: ng.IScope,
            private $location: ng.ILocationService) {
            //$scope.servers = [];
        }
    }
}