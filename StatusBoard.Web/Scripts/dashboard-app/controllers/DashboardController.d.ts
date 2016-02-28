/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
declare module Dashboard.Controllers {
    import DashboardScope = Interfaces.IDashboardScope;
    import ServerService = Dashboard.Services.ServerService;
    class DashboardController {
        private $scope;
        private $location;
        private $http;
        private serverService;
        private servers;
        static $inject: string[];
        constructor($scope: DashboardScope, $location: ng.ILocationService, $http: ng.IHttpService, serverService: ServerService);
    }
}
