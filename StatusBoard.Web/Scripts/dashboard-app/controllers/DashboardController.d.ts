/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
declare module Dashboard.Controllers {
    import DashboardScope = Interfaces.IDashboardScope;
    class DashboardController {
        private $scope;
        private $location;
        private $http;
        private servers;
        static $inject: string[];
        constructor($scope: DashboardScope, $location: ng.ILocationService, $http: ng.IHttpService);
    }
}
