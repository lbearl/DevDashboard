/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
module Dashboard.Controllers {
    import Server = Models.IServer;
    import ServerHistory = Models.ServerHistory;
    import ServerScope = Interfaces.IServerScope;
    import ServerHistoryService = Dashboard.Services.ServerHistoryService;
    "use strict";

    export class ServerController {
        private serverHistory: ServerHistory[];

        public static $inject = [
            "$scope",
            "$routeParams",
            "$http",
            "$interval",
            "ServerHistoryService"
        ];

        constructor(
            private $scope: ServerScope,
            private $routeParams: any, //the use of "any" here is a hack until I have time to build out all the ifaces needed
            private $http: any,
            private $interval: ng.IIntervalService,
            private $serverHistoryService: ServerHistoryService) {
            //get the data on page load
            this.getData(this.$routeParams.serverid, $scope);
            //also wire up a function to periodically retrieve the data
            var intervalFn = () => this.getData(this.$routeParams.serverid, $scope);
            //now setup the $interval service to update the data every 5 seconds
            $scope.interval = $interval(intervalFn, 5000);

            $scope.chartOptions = {
                chart: {
                    type: "sparklinePlus",
                    height: 200,
                    x: (d, i) => i,
                    y: (d) => d.PingResponseTime,
                    xTickFormat: d => d3.time.format("%x %X")(new Date(this.$scope.chartData[d].TakenAt)),
                    duration: 250
                }
            }

            //upon destroying the controller, lets make sure that the interval is properly cancelled
            //note that interval lifetime is outside that of the controller
            $scope.$on("$destroy", () => {
                if (angular.isDefined($scope.interval))
                    $interval.cancel($scope.interval);
            });

        }

        private getData(serverId: number, $scope: ServerScope) {
            var history = this.$serverHistoryService.getServerHistory(serverId);
            //turns out $http.get returns a promise, so instead of accessing the 
            //value directly, we need to defer actually using the values until they
            //have resolved
            history.then((value) => {
                $scope.serverHistory = value.serverHistory;
                $scope.chartData = value.timeSeries;
                $scope.title = value.hostName;
                //I'm keeping the chartoptions inside the promise then block because
                //chart data won't be populated until the promise resolves.
                $scope.chartOptions = {
                    chart: {
                        type: 'sparklinePlus',
                        height: 200,
                        x: (d, i) => i,
                        y: (d) => d.PingResponseTime,
                        xTickFormat: d => d3.time.format('%x %X')(new Date($scope.chartData[d].TakenAt)),
                        duration: 250
                    }
                }
            });


        }

    }

    angular.module("dashboard").controller("serverController", ["$scope", "$routeParams", "$http", "$interval", "ServerHistoryService", ServerController]);
}
