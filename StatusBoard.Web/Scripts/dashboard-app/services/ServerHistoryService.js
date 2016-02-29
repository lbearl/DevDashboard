var Dashboard;
(function (Dashboard) {
    var Services;
    (function (Services) {
        var ServerHistory = Dashboard.Models.ServerHistory;
        var ServerHistoryService = (function () {
            function ServerHistoryService($http) {
                this.$http = $http;
            }
            ServerHistoryService.prototype.getServerHistory = function (serverId) {
                var ret = new ServerHistory();
                var req = this.$http({
                    method: "Get",
                    url: "/api/ServerActions/" + serverId + "/GetServerHistoryForServer/0/250"
                }).then(function (response) {
                    ret.serverHistory = response.data["ServerHistory"];
                    ret.timeSeries = response.data["TimeSeries"];
                    ret.hostName = response.data["HostName"];
                });
                return req.then(function () { return ret; });
            };
            ServerHistoryService.$inject = ["$http"];
            return ServerHistoryService;
        })();
        Services.ServerHistoryService = ServerHistoryService;
        angular.module("dashboard").factory("ServerHistoryService", ["$http", function ($http) { return new ServerHistoryService($http); }]);
    })(Services = Dashboard.Services || (Dashboard.Services = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ServerHistoryService.js.map