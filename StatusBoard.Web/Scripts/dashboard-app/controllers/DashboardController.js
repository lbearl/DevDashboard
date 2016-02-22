/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
var Dashboard;
(function (Dashboard) {
    var Controllers;
    (function (Controllers) {
        "use strict";
        var DashboardController = (function () {
            function DashboardController($scope, $location) {
                this.$scope = $scope;
                this.$location = $location;
                //$scope.servers = [];
            }
            DashboardController.$inject = [
                '$scope',
                '$location'
            ];
            return DashboardController;
        })();
        Controllers.DashboardController = DashboardController;
    })(Controllers = Dashboard.Controllers || (Dashboard.Controllers = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=DashboardController.js.map