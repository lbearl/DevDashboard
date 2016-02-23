declare module Dashboard.Interfaces {
    import Server = Models.Server;
    import ServerHistory = Models.ServerHistory;
    interface IDashboardScope extends ng.IScope {
        servers: Server[];
    }
    interface IServerScope extends ng.IScope {
        title: string;
        serverHistory: ServerHistory[];
        chartData: {};
        chartOptions: {};
    }
}
