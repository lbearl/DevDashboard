/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
declare module Dashboard.Controllers {
    import ServerScope = Interfaces.IServerScope;
    class ServerController {
        private $scope;
        private $routeParams;
        private $http;
        private serverHistory;
        static $inject: string[];
        constructor($scope: ServerScope, $routeParams: any, $http: any);
    }
}
