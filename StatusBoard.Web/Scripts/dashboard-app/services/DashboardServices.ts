/// <reference path="../../../typings/browser/ambient/angular/angular.d.ts" />
/// <reference path="../../../typings/browser/ambient/angular-resource/angular-resource.d.ts" />
module Dashboard.Services {
    import Server = Models.Server;
    import ServerResource = Dashboard.Interfaces.IServerResource;

    export class ServerService {
        static $inject = ["ServerResource"];

        constructor(private $resource: ServerResource) {
            
        }
    }
    angular.module('dashboard.services').factory('ServerService', ServerResource);
}