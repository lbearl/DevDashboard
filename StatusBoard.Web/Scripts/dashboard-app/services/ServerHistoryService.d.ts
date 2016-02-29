declare module Dashboard.Services {
    import ServerHistory = Dashboard.Models.ServerHistory;
    class ServerHistoryService {
        private $http;
        static $inject: string[];
        constructor($http: ng.IHttpService);
        getServerHistory(serverId: number): ng.IPromise<ServerHistory>;
    }
}
