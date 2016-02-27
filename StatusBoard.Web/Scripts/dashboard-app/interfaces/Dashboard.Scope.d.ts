declare module Dashboard.Interfaces {
    import ServerHistory = Models.ServerHistory;
    interface IDashboardScope extends ng.IScope {
        servers: {};
    }
    interface IServerScope extends ng.IScope {
        title: string;
        serverHistory: ServerHistory[];
        chartData: {};
        chartOptions: {};
        interval: ng.IPromise<any>;
    }
}
