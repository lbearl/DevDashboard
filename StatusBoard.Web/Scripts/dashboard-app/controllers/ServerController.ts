/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
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
            private $http: any) {
            var server = new Server(1, 'The LA Girl', 'https://www.thelagirl.com', true);

            $http({
                method: 'GET',
                url: '/api/ServerActions/GetServerHistoryForServer?id=' + $routeParams.serverid
            }).then(response => {
                $scope.serverHistory = response.data.ServerHistory;
                $scope.chartData = response.data.TimeSeries;
                $scope.title = response.data.HostName;
                $scope.myChartOptions = {
                    xaxis: {
                        mode: "time",
                        timezone: "browser",
                        timeformat: "%Y/%m/%d %H:%M"
                    }
            };
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