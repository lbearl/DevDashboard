module Dashboard.Interfaces {
    import Server = Models.Server;
    import ServerHistory = Models.ServerHistory;

    export interface IDashboardScope extends ng.IScope {
        servers: {};
        issues: {};
    }

    export interface IServerScope extends ng.IScope {
        title: string;
        serverHistory: ServerHistory[];
        chartData: {};
        chartOptions: {};
        interval: ng.IPromise<any>;
    }
}