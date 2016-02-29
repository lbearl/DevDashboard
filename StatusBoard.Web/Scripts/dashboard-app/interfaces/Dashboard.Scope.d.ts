declare module Dashboard.Interfaces {
    interface IDashboardScope extends ng.IScope {
        servers: {};
        issues: {};
    }
    interface IServerScope extends ng.IScope {
        title: string;
        serverHistory: {};
        chartData: {};
        chartOptions: {};
        interval: ng.IPromise<any>;
    }
}
