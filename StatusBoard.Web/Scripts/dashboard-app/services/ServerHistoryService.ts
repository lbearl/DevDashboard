module Dashboard.Services {
    import ServerScope = Interfaces.IServerScope;
    import ServerHistory = Dashboard.Models.ServerHistory;

    export class ServerHistoryService {

        static $inject = ["$http"];

        constructor(private $http: ng.IHttpService) {

        }

        getServerHistory(serverId: number): ng.IPromise<ServerHistory> {
            var ret = new ServerHistory();
            var req = this.$http({
                method: "Get",
                url: "/api/ServerActions/" + serverId + "/GetServerHistoryForServer/0/250"
            }).then(response => {
                ret.serverHistory = response.data["ServerHistory"];
                ret.timeSeries = response.data["TimeSeries"];
                ret.hostName = response.data["HostName"];
            });
            return req.then(() => { return ret });
        }
    }
    angular.module("dashboard").factory("ServerHistoryService", ["$http", ($http) => new ServerHistoryService($http)]);
}