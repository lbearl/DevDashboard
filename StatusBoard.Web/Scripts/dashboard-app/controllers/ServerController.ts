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
            '$http',
            '$interval'
        ];

        constructor(
            private $scope: ServerScope,
            private $routeParams: any, //the use of "any" here is a hack until I have time to build out all the ifaces needed
            private $http: any,
            private $interval: ng.IIntervalService) {
            //get the data on page load
            this.getData($http, $scope, $routeParams);
            //also wire up a function to periodically retrieve it
            var intervalFn = () => this.getData($http, $scope, $routeParams);
            //now setup the $interval service to update the data every 1 minute
            $scope.interval = $interval(intervalFn, 60000);

            //upon destroying the controller, lets make sure that the interval is properly cancelled
            //note that interval lifetime is outside that of the controller
            $scope.$on("$destroy", () => {
                if (angular.isDefined($scope.interval))
                    $interval.cancel($scope.interval);
            });

        }

        //this function retrieves all data using the $http service. 
        private getData($http: ng.IHttpService, $scope: ServerScope, $routeParams: any) {
            $http({
                method: 'POST',
                url: '/api/ServerActions/' + $routeParams.serverid + '/GetServerHistoryForServer/0/250'
            }).then(response => {
                $scope.serverHistory = response.data['ServerHistory'];
                $scope.chartData = response.data['TimeSeries'];
                $scope.title = response.data['HostName'];
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
                //fail... should probably do something in the event that the POST fails for some reason...
            });
        }




    }

    angular.module('dashboard').controller('serverController', ['$scope', '$routeParams', '$http', '$interval', ServerController]);
}
