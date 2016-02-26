/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ServerController = (function () {
            function ServerController($scope, $routeParams, //the use of "any" here is a hack until I have time to build out all the ifaces needed
                $http, $interval) {
                this.$scope = $scope;
                this.$routeParams = $routeParams;
                this.$http = $http;
                this.$interval = $interval;
                $interval(function () {
                    $http({
                        method: 'GET',
                        url: '/api/ServerActions/GetServerHistoryForServer?id=' + $routeParams.serverid
                    }).then(function (response) {
                        $scope.serverHistory = response.data.ServerHistory;
                        $scope.chartData = response.data.TimeSeries;
                        $scope.title = response.data.HostName;
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
                    }, function (response) {
                        //fail
                    });
                }, 5000);
            }
            ServerController.$inject = [
                '$scope',
                '$routeParams',
                '$http'
            ];
            return ServerController;
        })();
        Controllers.ServerController = ServerController;
        angular.module('dashboard').controller('serverController', ['$scope', '$routeParams', '$http', ServerController]);
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ServerController.js.map