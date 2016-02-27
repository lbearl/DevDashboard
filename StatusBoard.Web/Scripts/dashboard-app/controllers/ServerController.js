/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var ServerController = (function () {
            function ServerController($scope, $routeParams, //the use of "any" here is a hack until I have time to build out all the ifaces needed
                $http, $interval) {
                var _this = this;
                this.$scope = $scope;
                this.$routeParams = $routeParams;
                this.$http = $http;
                this.$interval = $interval;
                //get the data on page load
                this.getData($http, $scope, $routeParams);
                //also wire up a function to periodically retrieve it
                var intervalFn = function () { return _this.getData($http, $scope, $routeParams); };
                //now setup the $interval service to update the data every 1 minute
                $scope.interval = $interval(intervalFn, 60000);
                //upon destroying the controller, lets make sure that the interval is properly cancelled
                //note that interval lifetime is outside that of the controller
                $scope.$on("$destroy", function () {
                    if (angular.isDefined($scope.interval))
                        $interval.cancel($scope.interval);
                });
            }
            //this function retrieves all data using the $http service. 
            ServerController.prototype.getData = function ($http, $scope, $routeParams) {
                $http({
                    method: 'POST',
                    url: '/api/ServerActions/' + $routeParams.serverid + '/GetServerHistoryForServer/0/250'
                }).then(function (response) {
                    $scope.serverHistory = response.data['ServerHistory'];
                    $scope.chartData = response.data['TimeSeries'];
                    $scope.title = response.data['HostName'];
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
                    //fail... should probably do something in the event that the POST fails for some reason...
                });
            };
            ServerController.$inject = [
                '$scope',
                '$routeParams',
                '$http',
                '$interval'
            ];
            return ServerController;
        })();
        Controllers.ServerController = ServerController;
        angular.module('dashboard').controller('serverController', ['$scope', '$routeParams', '$http', '$interval', ServerController]);
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ServerController.js.map