/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
declare module Dashboard.Services {
    import Server = Models.Server;
    class ServerService {
        private $resource;
        static $inject: string[];
        constructor($resource: ng.resource.IResource<Server>);
    }
}
