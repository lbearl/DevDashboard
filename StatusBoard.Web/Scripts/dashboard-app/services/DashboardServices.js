/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Services;
    (function (Services) {
        var ServerService = (function () {
            function ServerService(builder) {
                this.builder = builder;
            }
            ServerService.prototype.getServers = function () {
                return this.builder.getServerResource().query();
            };
            ServerService.$inject = ["ResourceBuilder"];
            return ServerService;
        })();
        Services.ServerService = ServerService;
        angular.module('dashboard').factory('ServerService', ['ResourceBuilder', function (builder) { return builder.getServerResource(); }]);
    })(Services = Dashboard.Services || (Dashboard.Services = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardServices.js.map