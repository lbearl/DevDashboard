/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        var Server = Dashboard.Models.Server;
        var ServerHistory = Dashboard.Models.ServerHistory;
        "use strict";
        var ServerController = (function () {
            function ServerController($scope, $location, $http) {
                this.$scope = $scope;
                this.$location = $location;
                this.$http = $http;
                var server = new Server(1, 'The LA Girl', 'https://www.thelagirl.com', true);
                /*
                $http({
                    method: 'GET',
                    url: '/api/ServerActions/GetServerHistoryForServer'
                })
                */
                //forcibly injecting the servers into the scope for now
                $scope.serverHistory = [new ServerHistory(server, server.serverId, 'OK', '1020', 'Valid', new Date(2016, 11, 11, 12, 0)),
                    new ServerHistory(server, server.serverId, 'OK', '740', 'Valid', new Date(2016, 11, 11, 12, 0))];
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