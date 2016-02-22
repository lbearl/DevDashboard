/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
declare module Dashboard.Controllers {
    import ServerScope = Interfaces.IServerScope;
    class ServerController {
        private $scope;
        private $location;
        private $http;
        private serverHistory;
        static $inject: string[];
        constructor($scope: ServerScope, $location: ng.ILocationService, $http: any);
    }
}
