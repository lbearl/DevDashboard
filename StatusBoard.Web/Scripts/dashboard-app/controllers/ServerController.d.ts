/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
declare module Dashboard.Controllers {
    import ServerScope = Interfaces.IServerScope;
    import ServerHistoryService = Dashboard.Services.ServerHistoryService;
    class ServerController {
        private $scope;
        private $routeParams;
        private $http;
        private $interval;
        private $serverHistoryService;
        private serverHistory;
        static $inject: string[];
        constructor($scope: ServerScope, $routeParams: any, $http: any, $interval: ng.IIntervalService, $serverHistoryService: ServerHistoryService);
        private getData(serverId, $scope);
    }
}
