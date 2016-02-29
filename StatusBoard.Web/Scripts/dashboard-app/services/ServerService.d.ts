/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
declare module Dashboard.Services {
    import ResourceBuilder = Dashboard.Factories.ResourceBuilder;
    import Service = Interfaces.IServerService;
    class ServerService implements Service {
        private builder;
        static $inject: string[];
        private serverResource;
        constructor(builder: ResourceBuilder);
        getServers(): any;
    }
}
