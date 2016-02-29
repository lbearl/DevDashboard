/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ServerController = (function () {
            function ServerController($scope, $routeParams, //the use of "any" here is a hack until I have time to build out all the ifaces needed
                $http, $interval, $serverHistoryService) {
                var _this = this;
                this.$scope = $scope;
                this.$routeParams = $routeParams;
                this.$http = $http;
                this.$interval = $interval;
                this.$serverHistoryService = $serverHistoryService;
                //get the data on page load
                this.getData(this.$routeParams.serverid, $scope);
                //also wire up a function to periodically retrieve the data
                var intervalFn = function () { return _this.getData(_this.$routeParams.serverid, $scope); };
                //now setup the $interval service to update the data every 5 seconds
                $scope.interval = $interval(intervalFn, 5000);
                $scope.chartOptions = {
                    chart: {
                        type: "sparklinePlus",
                        height: 200,
                        x: function (d, i) { return i; },
                        y: function (d) { return d.PingResponseTime; },
                        xTickFormat: function (d) { return d3.time.format("%x %X")(new Date(_this.$scope.chartData[d].TakenAt)); },
                        duration: 250
                    }
                };
                //upon destroying the controller, lets make sure that the interval is properly cancelled
                //note that interval lifetime is outside that of the controller
                $scope.$on("$destroy", function () {
                    if (angular.isDefined($scope.interval))
                        $interval.cancel($scope.interval);
                });
            }
            ServerController.prototype.getData = function (serverId, $scope) {
                var history = this.$serverHistoryService.getServerHistory(serverId);
                //turns out $http.get returns a promise, so instead of accessing the 
                //value directly, we need to defer actually using the values until they
                //have resolved
                history.then(function (value) {
                    $scope.serverHistory = value.serverHistory;
                    $scope.chartData = value.timeSeries;
                    $scope.title = value.hostName;
                    //I'm keeping the chartoptions inside the promise then block because
                    //chart data won't be populated until the promise resolves.
                    $scope.chartOptions = {
                        chart: {
                            type: 'sparklinePlus',
                            height: 200,
                            x: function (d, i) { return i; },
                            y: function (d) { return d.PingResponseTime; },
                            xTickFormat: function (d) { return d3.time.format('%x %X')(new Date($scope.chartData[d].TakenAt)); },
                            duration: 250
                        }
                    };
                });
            };
            ServerController.$inject = [
                "$scope",
                "$routeParams",
                "$http",
                "$interval",
                "ServerHistoryService"
            ];
            return ServerController;
        })();
        Controllers.ServerController = ServerController;
        angular.module("dashboard").controller("serverController", ["$scope", "$routeParams", "$http", "$interval", "ServerHistoryService", ServerController]);
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ServerController.js.map