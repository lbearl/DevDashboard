/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
"use strict";
var Dashboard;
(function (Dashboard) {
    var Services;
    (function (Services) {
        var ServerService = (function () {
            function ServerService(builder) {
                this.builder = builder;
                this.serverResource = builder.getServerResource();
            }
            ServerService.prototype.getServers = function () {
                return this.serverResource.query();
            };
            ServerService.$inject = ["ResourceBuilder"];
            return ServerService;
        })();
        Services.ServerService = ServerService;
        angular.module("dashboard").factory("ServerService", ["ResourceBuilder", function (resourceBuilder) { return new ServerService(resourceBuilder); }]);
    })(Services = Dashboard.Services || (Dashboard.Services = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ServerService.js.map