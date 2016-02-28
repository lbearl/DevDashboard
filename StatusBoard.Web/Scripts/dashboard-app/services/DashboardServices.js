/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Services;
    (function (Services) {
        var ServerService = (function () {
            function ServerService($resource) {
                this.$resource = $resource;
            }
            ServerService.$inject = ["$resource"];
            return ServerService;
        })();
        Services.ServerService = ServerService;
        angular.module('dashboard.services').factory('ServerService', function ($resource) { return $resource('/api/ServerActions/Servers/:id'); });
    })(Services = Dashboard.Services || (Dashboard.Services = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardServices.js.map