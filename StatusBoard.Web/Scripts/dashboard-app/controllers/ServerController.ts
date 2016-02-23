﻿/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
module Dashboard.Controllers {
    import Server = Models.Server;
    import ServerHistory = Models.ServerHistory;
    import ServerScope = Interfaces.IServerScope;
    "use strict";

    export class ServerController {
        private serverHistory: ServerHistory[];

        public static $inject = [
            '$scope',
            '$routeParams',
            '$http'
        ];

        constructor(
            private $scope: ServerScope,
            private $routeParams: any, //the use of "any" here is a hack until I have time to build out all the ifaces needed
            private $http: any,
            private $interval: ng.IIntervalService) {
            $http({
                method: 'GET',
                url: '/api/ServerActions/GetServerHistoryForServer?id=' + $routeParams.serverid
            }).then(response => {
                $scope.serverHistory = response.data.ServerHistory;
                $scope.chartData = response.data.TimeSeries;
                $scope.title = response.data.HostName;
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
            }, response => {
                //fail
            });

            //forcibly injecting the servers into the scope for now
            //$scope.serverHistory = [new ServerHistory(server, server.serverId, 'OK', '1020', 'Valid', new Date(2016, 11, 11, 12, 0)),
            //    new ServerHistory(server, server.serverId, 'OK', '740', 'Valid', new Date(2016, 11, 11, 12, 0))];
        }
    }

    angular.module('dashboard').controller('serverController', ['$scope', '$routeParams', '$http', ServerController]);
}