/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
declare module Dashboard.Controllers {
    class DashboardController {
        private $scope;
        private $location;
        private servers;
        static $inject: string[];
        constructor($scope: ng.IScope, $location: ng.ILocationService);
    }
}
